using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Models;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using QuanLyKho.Data;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKho.Views
{
    public partial class OutputInfoForm : UserControl
    {
        private readonly QuanlyKhoDbContext _context;
        private OutputInfo? _outputInfo;
        private readonly int _outputId;
        private byte[]? _selectedImageData;

        public Action? OnOutputInfoUpdated { get; set; }

        public OutputInfoForm(int outputId)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _outputId = outputId;
            InitializeForm();
        }

        public OutputInfoForm(OutputInfo outputInfo)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _outputInfo = _context.OutputInfos
                .Include(oi => oi.IdProductNavigation)
                .Include(oi => oi.IdCustomerNavigation)
                .Include(oi => oi.IdInputInfoNavigation)
                .FirstOrDefault(oi => oi.Id == outputInfo.Id);
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadComboBoxData();
            SetupStatusComboBox();
            PopulateFields();
            SetupEventHandlers();
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Load products with available quantity
                ProductComboBox.ItemsSource = _context.Products
                    .Where(p => p.Quantity > 0)
                    .ToList();

                // Load all active customers
                CustomerComboBox.ItemsSource = _context.Customers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetupStatusComboBox()
        {
            StatusComboBox.Items.Clear();
            StatusComboBox.Items.Add(new ComboBoxItem { Content = "Đang xử lý" });
            StatusComboBox.Items.Add(new ComboBoxItem { Content = "Hoàn thành" });
        }

        private void PopulateFields()
        {
            if (_outputInfo == null) return;

            ProductComboBox.SelectedValue = _outputInfo.IdProduct;
            CustomerComboBox.SelectedValue = _outputInfo.IdCustomer;
            CountTextBox.Text = _outputInfo.Count.ToString("N0");

            if (_outputInfo.IdInputInfoNavigation != null)
            {
                OutputPriceTextBox.Text = _outputInfo.IdInputInfoNavigation.OutputPrice.ToString("N0");
            }

            // Select status in combobox
            foreach (ComboBoxItem item in StatusComboBox.Items)
            {
                if (item.Content.ToString() == _outputInfo.Status)
                {
                    StatusComboBox.SelectedItem = item;
                    break;
                }
            }

            // Load contract image if exists
            if (_outputInfo.ContractImage != null && _outputInfo.ContractImage.Length > 0)
            {
                _selectedImageData = _outputInfo.ContractImage;
                using var ms = new MemoryStream(_outputInfo.ContractImage);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                ContractImageView.Source = bitmap;
            }
        }

        private void SetupEventHandlers()
        {
            ProductComboBox.SelectionChanged += ProductComboBox_SelectionChanged;
        }

        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductComboBox.SelectedValue is int productId)
            {
                var product = _context.Products.Find(productId);
                if (product != null)
                {
                    AvailableQuantityText.Text = $"Số lượng có sẵn: {product.Quantity:N0}";

                    // Tự động điền giá xuất nếu có
                    var inputInfo = _context.InputInfos
                        .Include(ii => ii.IdProductSupplierNavigation)
                        .FirstOrDefault(ii => ii.IdProductSupplierNavigation.IdProduct == productId);

                    if (inputInfo != null)
                    {
                        OutputPriceTextBox.Text = inputInfo.OutputPrice.ToString("N0");
                    }
                }
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn ảnh chứng từ"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _selectedImageData = File.ReadAllBytes(openFileDialog.FileName);
                ContractImageView.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInputs()) return;

            var productId = (int)ProductComboBox.SelectedValue;
            var customerId = (int)CustomerComboBox.SelectedValue;
            var count = int.Parse(CountTextBox.Text);
            var outputPrice = decimal.Parse(OutputPriceTextBox.Text);
            var status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var product = _context.Products.Find(productId);
                if (product == null)
                {
                    ShowError("Sản phẩm không tồn tại!");
                    return;
                }

                if (product.Quantity < count && status == "Hoàn thành")
                {
                    ShowError($"Không đủ hàng trong kho! Số lượng có sẵn: {product.Quantity:N0}");
                    return;
                }

                var inputInfo = FindMatchingInputInfo(productId, outputPrice);
                if (inputInfo == null)
                {
                    ShowError("Không tìm thấy lô hàng nhập phù hợp!");
                    return;
                }

                SaveOutputInfo(product, inputInfo, customerId, count, status);
                UpdateProductQuantity(product, count, status);

                _context.SaveChanges();
                transaction.Commit();

                ShowSuccess("Lưu thông tin thành công!");
                OnOutputInfoUpdated?.Invoke();
                CloseWindow();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ShowError($"Lỗi khi lưu thông tin: {ex.Message}");
            }
        }

        private bool ValidateInputs()
        {
            if (ProductComboBox.SelectedValue == null)
            {
                ShowError("Vui lòng chọn sản phẩm!");
                return false;
            }

            if (CustomerComboBox.SelectedValue == null)
            {
                ShowError("Vui lòng chọn khách hàng!");
                return false;
            }

            if (!int.TryParse(CountTextBox.Text, out int count) || count <= 0)
            {
                ShowError("Số lượng phải là số nguyên dương!");
                return false;
            }

            if (!decimal.TryParse(OutputPriceTextBox.Text, out decimal outputPrice) || outputPrice < 0)
            {
                ShowError("Giá xuất phải là số dương!");
                return false;
            }

            if (StatusComboBox.SelectedItem == null)
            {
                ShowError("Vui lòng chọn trạng thái!");
                return false;
            }

            return true;
        }

        private InputInfo? FindMatchingInputInfo(int productId, decimal outputPrice)
        {
            return _context.InputInfos
                .Include(ii => ii.IdProductSupplierNavigation)
                .FirstOrDefault(ii => ii.IdProductSupplierNavigation.IdProduct == productId &&
                                    ii.OutputPrice == outputPrice);
        }

        private void SaveOutputInfo(Product product, InputInfo inputInfo, int customerId, int count, string status)
        {
            if (_outputInfo == null)
            {
                _outputInfo = new OutputInfo
                {
                    IdOutput = _outputId,
                    IdProduct = product.Id,
                    IdCustomer = customerId,
                    IdInputInfo = inputInfo.Id,
                    Count = count,
                    Status = status,
                    ContractImage = _selectedImageData
                };
                _context.OutputInfos.Add(_outputInfo);
            }
            else
            {
                _outputInfo.IdProduct = product.Id;
                _outputInfo.IdCustomer = customerId;
                _outputInfo.IdInputInfo = inputInfo.Id;
                _outputInfo.Count = count;
                _outputInfo.Status = status;
                _outputInfo.ContractImage = _selectedImageData ?? _outputInfo.ContractImage;
            }
        }

        private void UpdateProductQuantity(Product product, int count, string status)
        {
            if (status == "Hoàn thành")
            {
                product.Quantity -= count;
            }
            else if (_outputInfo?.Status == "Hoàn thành" && status != "Hoàn thành")
            {
                // Nếu trạng thái cũ là Hoàn thành và mới không phải thì hoàn trả số lượng
                product.Quantity += _outputInfo.Count;
            }
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseWindow()
        {
            Window.GetWindow(this)?.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
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
        private QuanlyKhoDbContext _context;
        private OutputInfo? _outputInfo;
        private int _outputId;

        public Action? OnOutputInfoUpdated { get; set; }

        public OutputInfoForm(int outputId)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _outputId = outputId;
            LoadData();
            PopulateFields();
        }

        public OutputInfoForm(OutputInfo outputInfo)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _outputInfo = _context.OutputInfos
                .Include(oi => oi.IdProductNavigation)
                .Include(oi => oi.IdCustomerNavigation)
                .Include(oi => oi.IdInputInfoNavigation)
                .FirstOrDefault(oi => oi.Id == outputInfo.Id) ?? outputInfo;

            LoadData();
            PopulateFields();
        }

        private void LoadData()
        {
            // Load products
            ProductComboBox.ItemsSource = _context.Products.ToList();
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SelectedValuePath = "Id";

            // Load customers
            CustomerComboBox.ItemsSource = _context.Customers.ToList();
            CustomerComboBox.DisplayMemberPath = "Name";
            CustomerComboBox.SelectedValuePath = "Id";

            // Load estimated prices (from InputInfo)
            EstimatedPriceComboBox.ItemsSource = _context.InputInfos
                .Select(ii => new { ii.OutputPrice })
                .Distinct()
                .ToList();
            EstimatedPriceComboBox.DisplayMemberPath = "OutputPrice";
            EstimatedPriceComboBox.SelectedValuePath = "OutputPrice";
        }

        private byte[]? selectedImageData;

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn ảnh chứng từ"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImageData = File.ReadAllBytes(openFileDialog.FileName);
                ContractImageView.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void PopulateFields()
        {
            if (_outputInfo != null)
            {
                ProductComboBox.SelectedValue = _outputInfo.IdProduct;
                CustomerComboBox.SelectedValue = _outputInfo.IdCustomer;
                CountTextBox.Text = _outputInfo.Count.ToString("N0");

                // Set output price if available from InputInfo
                if (_outputInfo.IdInputInfoNavigation != null)
                {
                    EstimatedPriceComboBox.SelectedValue = _outputInfo.IdInputInfoNavigation.OutputPrice;
                    OutputPriceTextBox.Text = _outputInfo.IdInputInfoNavigation.OutputPrice.ToString("N0");
                }

                foreach (ComboBoxItem item in StatusComboBox.Items)
                {
                    if (item.Content.ToString() == _outputInfo.Status)
                    {
                        StatusComboBox.SelectedItem = item;
                        break;
                    }
                }

                if (_outputInfo.ContractImage != null && _outputInfo.ContractImage.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(_outputInfo.ContractImage))
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        ContractImageView.Source = bitmap;
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (CustomerComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(CountTextBox.Text, out int count) || count <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(OutputPriceTextBox.Text, out decimal outputPrice) || outputPrice < 0)
                {
                    MessageBox.Show("Giá xuất phải là số dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (StatusComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int productId = (int)ProductComboBox.SelectedValue;
                int customerId = (int)CustomerComboBox.SelectedValue;
                string status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

                // Find the corresponding InputInfo with matching product and price
                var inputInfo = _context.InputInfos
                    .Include(ii => ii.IdProductSupplierNavigation)
                    .ThenInclude(ps => ps.IdProductNavigation)
                    .FirstOrDefault(ii => ii.IdProductSupplierNavigation.IdProductNavigation.Id == productId &&
                                         ii.OutputPrice == outputPrice);

                if (inputInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhập phù hợp với sản phẩm và giá xuất!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    var product = _context.Products.Find(productId);
                    if (product == null)
                    {
                        MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (product.Quantity < count)
                    {
                        MessageBox.Show("Không đủ hàng trong kho!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (_outputInfo == null)
                    {
                        _outputInfo = new OutputInfo
                        {
                            IdOutput = _outputId,
                            IdProduct = productId,
                            IdCustomer = customerId,
                            IdInputInfo = inputInfo.Id,
                            Count = count,
                            Status = status,
                            ContractImage = selectedImageData
                        };
                        _context.OutputInfos.Add(_outputInfo);

                        if (status == "Hoàn thành")
                        {
                            product.Quantity -= count;
                            _context.Products.Update(product);
                        }
                    }
                    else
                    {
                        var existingInfo = _context.OutputInfos.Find(_outputInfo.Id);
                        if (existingInfo == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin xuất kho để cập nhật!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        int oldCount = existingInfo.Count;
                        string oldStatus = existingInfo.Status ?? string.Empty;

                        existingInfo.IdProduct = productId;
                        existingInfo.IdCustomer = customerId;
                        existingInfo.IdInputInfo = inputInfo.Id;
                        existingInfo.Count = count;
                        existingInfo.Status = status;
                        existingInfo.ContractImage = selectedImageData ?? existingInfo.ContractImage;

                        if (oldStatus == "Hoàn thành")
                        {
                            product.Quantity += oldCount;
                        }
                        if (status == "Hoàn thành")
                        {
                            product.Quantity -= count;
                            _context.Products.Update(product);
                        }
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show("Lưu thông tin thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnOutputInfoUpdated?.Invoke();
                    Window.GetWindow(this)?.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void EstimatedPriceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EstimatedPriceComboBox.SelectedValue != null)
            {
                OutputPriceTextBox.Text = EstimatedPriceComboBox.SelectedValue.ToString();
            }
        }
    }
}
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
    public partial class InputInfoForm : UserControl
    {
        private QuanlyKhoDbContext _context;
        private InputInfo? _inputInfo; // Declare as nullable
        private int _inputId;

        public Action? OnInputInfoUpdated { get; set; }

        public InputInfoForm(int inputId)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _inputId = inputId;
            LoadData();
            PopulateFields();
        }

        public InputInfoForm(InputInfo inputInfo)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            // Load đầy đủ thông tin từ database
            _inputInfo = _context.InputInfos
                .Include(ii => ii.IdProductSupplierNavigation)
                    .ThenInclude(ps => ps.IdProductNavigation)
                .Include(ii => ii.IdProductSupplierNavigation)
                    .ThenInclude(ps => ps.IdSupplierNavigation)
                .FirstOrDefault(ii => ii.Id == inputInfo.Id) ?? inputInfo;

            LoadData();
            PopulateFields();
        }

        private void LoadData()
        {
            // Load danh sách sản phẩm
            ProductComboBox.ItemsSource = _context.Products.ToList();
            ProductComboBox.DisplayMemberPath = "Name";
            ProductComboBox.SelectedValuePath = "Id";

            // Load danh sách nhà cung cấp
            SupplierComboBox.ItemsSource = _context.Suppliers.ToList();
            SupplierComboBox.DisplayMemberPath = "Name";
            SupplierComboBox.SelectedValuePath = "Id";
        }

        private byte[]? selectedImageData;

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn ảnh hợp đồng"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImageData = File.ReadAllBytes(openFileDialog.FileName);
                ContractImageView.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void PopulateFields()
        {
            if (_inputInfo != null)
            {
                // Hiển thị đúng sản phẩm và nhà cung cấp bằng ID
                ProductComboBox.SelectedValue = _inputInfo.IdProductSupplierNavigation?.IdProduct;
                SupplierComboBox.SelectedValue = _inputInfo.IdProductSupplierNavigation?.IdSupplier;

                CountTextBox.Text = _inputInfo.Count.ToString("N0");
                InputPriceTextBox.Text = _inputInfo.InputPrice.ToString("N0");
                OutputPriceTextBox.Text = _inputInfo.OutputPrice.ToString("N0");

                // Chọn đúng trạng thái trong ComboBox
                foreach (ComboBoxItem item in StatusComboBox.Items)
                {
                    if (item.Content.ToString() == _inputInfo.Status)
                    {
                        StatusComboBox.SelectedItem = item;
                        break;
                    }
                }

                // Hiển thị ảnh hợp đồng nếu có
                if (_inputInfo.ContractImage != null && _inputInfo.ContractImage.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(_inputInfo.ContractImage))
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
                // 1. VALIDATE DỮ LIỆU ĐẦU VÀO
                if (ProductComboBox.SelectedValue == null || SupplierComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và nhà cung cấp!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(CountTextBox.Text, out int count) || count <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!decimal.TryParse(InputPriceTextBox.Text, out decimal inputPrice) || inputPrice < 0)
                {
                    MessageBox.Show("Giá nhập phải là số dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                int supplierId = (int)SupplierComboBox.SelectedValue;
                string? status = ((ComboBoxItem?)StatusComboBox.SelectedItem)?.Content?.ToString();
                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                // 2. TÌM HOẶC TẠO LIÊN KẾT PRODUCT-SUPPLIER
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    // Tìm sản phẩm và nhà cung cấp
                    var product = _context.Products.Find(productId);
                    var supplier = _context.Suppliers.Find(supplierId);

                    if (product == null || supplier == null)
                    {
                        MessageBox.Show("Sản phẩm hoặc nhà cung cấp không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Tìm hoặc tạo mới ProductSupplier
                    var productSupplier = _context.ProductSuppliers
                        .Include(ps => ps.IdProductNavigation)
                        .FirstOrDefault(ps => ps.IdProduct == productId && ps.IdSupplier == supplierId);

                    if (productSupplier == null)
                    {
                        productSupplier = new ProductSupplier
                        {
                            IdProduct = productId,
                            IdSupplier = supplierId,
                            IdProductNavigation = product,
                            IdSupplierNavigation = supplier
                        };
                        _context.ProductSuppliers.Add(productSupplier);
                        _context.SaveChanges(); // Lưu ngay để có ID
                    }

                    if (_inputInfo == null)
                    {
                        // THÊM MỚI
                        _inputInfo = new InputInfo
                        {
                            IdInput = _inputId,
                            IdProductSupplier = productSupplier.Id,
                            Count = count,
                            InputPrice = inputPrice,
                            OutputPrice = outputPrice,
                            Status = status,
                            ContractImage = selectedImageData
                        };
                        _context.InputInfos.Add(_inputInfo);

                        if (status == "Hoàn thành")
                        {
                            product.Quantity += count;
                            _context.Products.Update(product);
                        }
                    }
                    else
                    {
                        var existingInfo = _context.InputInfos
                            .Include(ii => ii.IdProductSupplierNavigation)
                                .ThenInclude(ps => ps.IdProductNavigation)
                            .FirstOrDefault(ii => ii.Id == _inputInfo.Id);

                        if (existingInfo == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin nhập hàng để cập nhật!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        int oldCount = existingInfo.Count;
                        string oldStatus = existingInfo.Status ?? string.Empty;

                        // Cập nhật thông tin
                        existingInfo.IdProductSupplier = productSupplier.Id;
                        existingInfo.Count = count;
                        existingInfo.InputPrice = inputPrice;
                        existingInfo.OutputPrice = outputPrice;
                        existingInfo.Status = status;
                        existingInfo.ContractImage = selectedImageData ?? existingInfo.ContractImage;

                        // ĐIỀU CHỈNH SỐ LƯỢNG TỒN KHO
                        if (oldStatus == "Hoàn thành")
                        {
                            // Trừ đi số lượng cũ
                            existingInfo.IdProductSupplierNavigation.IdProductNavigation.Quantity -= oldCount;
                        }

                        if (status == "Hoàn thành")
                        {
                            // Cộng thêm số lượng mới
                            product.Quantity += count;
                            _context.Products.Update(product);
                        }
                    }

                    _context.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show("Lưu thông tin thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnInputInfoUpdated?.Invoke();
                    Window.GetWindow(this)?.Close();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
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
    }
}
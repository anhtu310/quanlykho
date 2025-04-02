using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class ProductForm : UserControl
    {
        private QuanlyKhoDbContext context;
        private Product? product;
        public Action? OnProductUpdated { get; set; } // Callback cập nhật danh sách

        public ProductForm()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            product = new Product
            {
                Quantity = 0
            };
            txtQuantity.Text = "0";
            LoadData();
        }

        public ProductForm(Product existingProduct) : this()
        {
            product = existingProduct;

            // Gán dữ liệu lên form
            txtName.Text = product.Name;
            txtQuantity.Text = product.Quantity.ToString("N0");
            cmbUnit.SelectedValue = product.IdUnit;
            cmbCategory.SelectedValue = product.CategoryId;
            txtWarning.Text = product.WarningQuantity?.ToString("N0");
        }

        private void LoadData()
        {
            try
            {

                // Lấy danh sách đơn vị tính
                cmbUnit.ItemsSource = context.Units.ToList();
                cmbUnit.DisplayMemberPath = "Name";
                cmbUnit.SelectedValuePath = "Id";

                // Lấy danh sách danh mục
                cmbCategory.ItemsSource = context.Categories.ToList();
                cmbCategory.DisplayMemberPath = "Name";
                cmbCategory.SelectedValuePath = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtWarning.Text) && !int.TryParse(txtWarning.Text, out _))
            {
                MessageBox.Show("Số lượng cảnh báo phải là số nguyên!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            product.Name = txtName.Text.Trim();
            product.WarningQuantity = int.TryParse(txtWarning.Text, out var warningQty) ? warningQty : (int?)null;
            product.IdUnit = (int)cmbUnit.SelectedValue;
            product.CategoryId = (int?)cmbCategory.SelectedValue;

            // Chỉ đặt Quantity = 0 khi tạo mới (Id == 0)
            if (product.Id == 0)
            {
                product.Quantity = 0;
                context.Products.Add(product);
            }
            else
            {
                // Khi chỉnh sửa, Quantity giữ nguyên giá trị hiện tại
                context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            try
            {
                context.SaveChanges();
                OnProductUpdated?.Invoke();
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu sản phẩm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}

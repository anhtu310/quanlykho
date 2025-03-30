using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class ProductForm : UserControl
    {
        private QuanlyKhoDbContext context;
        private Product product;
        public Action OnProductUpdated { get; set; } // Callback cập nhật danh sách

        public ProductForm()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            product = new Product(); // Tạo mới sản phẩm
            LoadSuppliersAndUnits(); // Tải danh sách nhà cung cấp và đơn vị
        }

        public ProductForm(Product existingProduct) : this()
        {
            product = existingProduct;

            // Gán dữ liệu lên form
            txtName.Text = product.Name;
            txtQuantity.Text = product.Quantity.ToString();
            cmbSupplier.SelectedValue = product.IdSupplier;
            cmbUnit.SelectedValue = product.IdUnit;
        }

        private void LoadSuppliersAndUnits()
        {
            try
            {
                // Lấy danh sách nhà cung cấp
                var suppliers = context.Suppliers.ToList();
                if (suppliers == null || suppliers.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhà cung cấp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    cmbSupplier.ItemsSource = suppliers;
                    cmbSupplier.DisplayMemberPath = "Name"; // Hiển thị tên nhà cung cấp
                    cmbSupplier.SelectedValuePath = "Id";  // Lưu ID nhà cung cấp
                }

                // Lấy danh sách đơn vị tính
                var units = context.Units.ToList();
                if (units == null || units.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu đơn vị tính!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    cmbUnit.ItemsSource = units;
                    cmbUnit.DisplayMemberPath = "Name"; // Hiển thị tên đơn vị
                    cmbUnit.SelectedValuePath = "Id";  // Lưu ID đơn vị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Lỗi",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Chuẩn hóa dữ liệu
            product.Name = txtName.Text.Trim();
            product.Quantity = int.Parse(txtQuantity.Text.Trim());
            product.IdSupplier = (int)cmbSupplier.SelectedValue;
            product.IdUnit = (int)cmbUnit.SelectedValue;

            // Nếu là sản phẩm mới
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }

            try
            {
                context.SaveChanges();
                OnProductUpdated?.Invoke();
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu sản phẩm: {ex.Message}", "Lỗi",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Close();
        }
    }
}

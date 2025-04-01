using System;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class SupplierForm : UserControl
    {
        private QuanlyKhoDbContext context;
        private Supplier? supplier;
        public Action? OnSupplierUpdated { get; set; }

        public SupplierForm(Supplier existingSupplier = null)
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();

            if (existingSupplier != null)
            {
                supplier = context.Suppliers.Find(existingSupplier.Id);
                if (supplier != null)
                {
                    txtName.Text = supplier.Name;
                    txtAddress.Text = supplier.Address;
                    txtEmail.Text = supplier.Email;
                    txtPhone.Text = supplier.Phone;
                    txtMoreInfo.Text = supplier.MoreInfo;
                }
            }
            else
            {
                supplier = new Supplier();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Tên và số điện thoại không được để trống!", "Lỗi",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Chuẩn hóa dữ liệu
            string name = txtName.Text.Trim().ToLower();  // Chuyển tên thành chữ thường
            string phone = txtPhone.Text.Trim();  // Giữ nguyên số điện thoại

            // Kiểm tra trùng tên nhà cung cấp
            bool nameExists = context.Suppliers
                .Any(s => s.Name.ToLower() == name  // Chuyển tên nhà cung cấp trong CSDL thành chữ thường
                       && (supplier.Id == 0 || s.Id != supplier.Id));

            if (nameExists)
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại!", "Lỗi",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra trùng số điện thoại
            bool phoneExists = context.Suppliers
                .Any(s => s.Phone == phone  // Kiểm tra số điện thoại trực tiếp
                       && (supplier.Id == 0 || s.Id != supplier.Id));

            if (phoneExists)
            {
                MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi",
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Cập nhật thông tin
            supplier.Name = txtName.Text.Trim();
            supplier.Address = txtAddress.Text.Trim();
            supplier.Email = txtEmail.Text.Trim();
            supplier.Phone = txtPhone.Text.Trim();
            supplier.MoreInfo = txtMoreInfo.Text.Trim();

            if (supplier.Id == 0)
            {
                supplier.ContactDate = DateTime.Now;
                context.Suppliers.Add(supplier);
            }

            try
            {
                context.SaveChanges();
                OnSupplierUpdated?.Invoke();
                ((Window)this.Parent).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu nhà cung cấp: {ex.Message}", "Lỗi",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Close();
        }
    }
}

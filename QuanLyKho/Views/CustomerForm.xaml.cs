using System;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class CustomerForm : UserControl
    {
        private QuanlyKhoDbContext context;
        private Customer customer;
        public Action? OnCustomerUpdated { get; set; } // Callback cập nhật danh sách

        public CustomerForm()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            customer = new Customer(); // Tạo mới khách hàng
        }

        public CustomerForm(Customer existingCustomer) : this()
        {
            customer = existingCustomer;

            // Gán dữ liệu lên form
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email;
            txtMoreInfo.Text = customer.MoreInfo;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Kiểm tra trùng số điện thoại (nếu có nhập)
            if (!string.IsNullOrEmpty(phone))
            {
                bool phoneExists = context.Customers
                    .Any(c => c.Phone == phone && c.Id != customer.Id); // Bỏ qua bản ghi hiện tại khi chỉnh sửa

                if (phoneExists)
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Kiểm tra trùng email (nếu có nhập)
            if (!string.IsNullOrEmpty(email))
            {
                bool emailExists = context.Customers
                    .Any(c => c.Email == email && c.Id != customer.Id); // Bỏ qua bản ghi hiện tại khi chỉnh sửa

                if (emailExists)
                {
                    MessageBox.Show("Email đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // Cập nhật thông tin khách hàng
            customer.Name = txtName.Text.Trim();
            customer.Address = txtAddress.Text.Trim();
            customer.Phone = phone;
            customer.Email = email;
            customer.MoreInfo = txtMoreInfo.Text.Trim();

            if (customer.Id == 0)
            {
                customer.ContactDate = DateOnly.FromDateTime(DateTime.Now);
                context.Customers.Add(customer);
            }
            else
            {
                // 🔥 Fix lỗi: Đảm bảo entity được theo dõi đúng cách
                var existingCustomer = context.Customers.Find(customer.Id);
                if (existingCustomer != null)
                {
                    context.Entry(existingCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Detached; // Xóa theo dõi cũ
                }

                context.Customers.Update(customer); // Cập nhật khách hàng
            }

            try
            {
                context.SaveChanges();
                OnCustomerUpdated?.Invoke();
                Window.GetWindow(this)?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu khách hàng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Close();
        }
    }
}

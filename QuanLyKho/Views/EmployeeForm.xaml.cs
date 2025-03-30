using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : UserControl
    {
        private Employee _currentEmployee;
        public Action OnEmployeeUpdated;

        public EmployeeForm(Employee employee = null)
        {
            InitializeComponent();
            _currentEmployee = employee;

            if (_currentEmployee != null)
            {
                // Nếu có nhân viên => Load dữ liệu lên form
                txtName.Text = _currentEmployee.Name;
                txtAddress.Text = _currentEmployee.Address;
                txtPhone.Text = _currentEmployee.Phone;
                txtEmail.Text = _currentEmployee.Email;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new QuanlyKhoDbContext())
            {
                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Kiểm tra trùng số điện thoại (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    var duplicatePhone = context.Employees
                        .Any(emp => emp.Phone == txtPhone.Text.Trim() &&
                                    (_currentEmployee == null || emp.Id != _currentEmployee.Id));

                    if (duplicatePhone)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại!", "Lỗi",
                                      MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                // Kiểm tra trùng email (nếu có nhập)
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    var duplicateEmail = context.Employees
                        .Any(emp => emp.Email == txtEmail.Text.Trim() &&
                                    (_currentEmployee == null || emp.Id != _currentEmployee.Id));

                    if (duplicateEmail)
                    {
                        MessageBox.Show("Email đã tồn tại!", "Lỗi",
                                      MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                // Tiến hành lưu dữ liệu
                if (_currentEmployee == null) // Thêm mới
                {
                    var newEmployee = new Employee
                    {
                        Name = txtName.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Status = true
                    };
                    context.Employees.Add(newEmployee);
                }
                else // Chỉnh sửa
                {
                    var employeeToUpdate = context.Employees.FirstOrDefault(e => e.Id == _currentEmployee.Id);
                    if (employeeToUpdate != null)
                    {
                        employeeToUpdate.Name = txtName.Text.Trim();
                        employeeToUpdate.Address = txtAddress.Text.Trim();
                        employeeToUpdate.Phone = txtPhone.Text.Trim();
                        employeeToUpdate.Email = txtEmail.Text.Trim();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                try
                {
                    context.SaveChanges();
                    MessageBox.Show(_currentEmployee == null ? "Thêm nhân viên thành công!" : "Cập nhật nhân viên thành công!",
                                  "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    Window.GetWindow(this)?.Close();
                    OnEmployeeUpdated?.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu nhân viên: {ex.Message}", "Lỗi",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }


    }
}

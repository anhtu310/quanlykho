﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanLyKho.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKho.Views
{
    public partial class EmployeeView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Employee> Employees { get; set; }

        public EmployeeView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            loadData();
        }

        private void loadData()
        {
            Dispatcher.Invoke(() =>
            {
                var list = context.Employees.AsNoTracking().ToList();
                Employees = new ObservableCollection<Employee>(list);
                lvEmployee.ItemsSource = Employees;
            });
        }


        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            var employee = (sender as FrameworkElement).DataContext as Employee;
            if (employee != null)
            {
                if (MessageBox.Show($"Bạn có chắc muốn đổi trạng thái nhân viên {employee.Name}?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    employee.Status = !employee.Status;
                    context.SaveChanges();
                    loadData();
                }
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var form = new EmployeeForm(); // Truyền không có tham số để tạo nhân viên mới
            form.OnEmployeeUpdated = loadData;
            var window = new Window
            {
                Content = form,
                Title = "Thêm nhân viên",
                Width = 350,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
            loadData(); // Cập nhật danh sách
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchEmployee();
        }

        // Bấm Enter cũng tìm kiếm luôn
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchEmployee();
            }
        }

        private void SearchEmployee()
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                lvEmployee.ItemsSource = Employees; // Load full
            }
            else
            {
                var filtered = Employees.Where(emp =>
                    (!string.IsNullOrEmpty(emp.Name) && emp.Name.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(emp.Phone) && emp.Phone.Contains(keyword))
                ).ToList();

                lvEmployee.ItemsSource = filtered;
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Employee selectedEmployee)
            {
                var form = new EmployeeForm(selectedEmployee);
                form.OnEmployeeUpdated = loadData;
                var window = new Window
                {
                    Content = form,
                    Title = "Chỉnh sửa nhân viên",
                    Width = 350,
                    Height = 300,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
                loadData(); // Cập nhật lại danh sách
            }
        }


        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Employee selectedEmployee)
            {
                var result = MessageBox.Show($"Xóa nhân viên {selectedEmployee.Name}?", "Xác nhận xóa",
                                             MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Xóa trong database
                        context.Employees.Remove(selectedEmployee);
                        context.SaveChanges();

                        // Xóa khỏi danh sách hiển thị
                        Employees.Remove(selectedEmployee);
                        lvEmployee.ItemsSource = null;
                        lvEmployee.ItemsSource = Employees; // Refresh ListView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


    }
}

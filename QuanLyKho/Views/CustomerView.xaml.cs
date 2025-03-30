using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;
using QuanLyKho.Views;

namespace QuanLyKho.Views
{
    public partial class CustomerView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            loadData();
        }

        private void loadData()
        {
            Dispatcher.Invoke(() =>
            {
                var list = context.Customers.AsNoTracking().ToList();
                Customers = new ObservableCollection<Customer>(list);
                lvCustomer.ItemsSource = Customers;
            });
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var form = new CustomerForm();
            form.OnCustomerUpdated = loadData;
            var window = new Window
            {
                Content = form,
                Title = "Thêm khách hàng",
                Width = 350,
                Height = 350,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
            loadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomer();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchCustomer();
            }
        }

        private void SearchCustomer()
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                lvCustomer.ItemsSource = Customers;
            }
            else
            {
                var filtered = Customers.Where(cus =>
                    (!string.IsNullOrEmpty(cus.Name) && cus.Name.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(cus.Phone) && cus.Phone.Contains(keyword))
                ).ToList();

                lvCustomer.ItemsSource = filtered;
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Customer selectedCustomer)
            {
                var form = new CustomerForm(selectedCustomer);
                form.OnCustomerUpdated = loadData;
                var window = new Window
                {
                    Content = form,
                    Title = "Chỉnh sửa khách hàng",
                    Width = 350,
                    Height = 350,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
                loadData();
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Customer selectedCustomer)
            {
                var result = MessageBox.Show($"Xóa khách hàng {selectedCustomer.Name}?", "Xác nhận xóa",
                                             MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        context.Customers.Remove(selectedCustomer);
                        context.SaveChanges();

                        Customers.Remove(selectedCustomer);
                        lvCustomer.ItemsSource = null;
                        lvCustomer.ItemsSource = Customers;
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

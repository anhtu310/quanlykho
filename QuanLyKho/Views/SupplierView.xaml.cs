using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanLyKho.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Data;

namespace QuanLyKho.Views
{
    public partial class SupplierView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Supplier>? Suppliers { get; set; }

        public SupplierView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            LoadData();
        }

        private void LoadData()
        {
            Dispatcher.Invoke(() =>
            {
                var list = context.Suppliers.AsNoTracking().ToList();
                Suppliers = new ObservableCollection<Supplier>(list);
                lvSupplier.ItemsSource = Suppliers;
            });
        }

        private void AddSupplier_Click(object sender, RoutedEventArgs e)
        {
            var form = new SupplierForm(); // Form thêm mới
            form.OnSupplierUpdated = LoadData;
            var window = new Window
            {
                Content = form,
                Title = "Thêm nhà cung cấp",
                Width = 400,
                Height = 400,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
        }

        private void EditSupplier_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Supplier selectedSupplier)
            {
                var form = new SupplierForm(selectedSupplier); // Form chỉnh sửa
                form.OnSupplierUpdated = LoadData;
                var window = new Window
                {
                    Content = form,
                    Title = "Chỉnh sửa nhà cung cấp",
                    Width = 400,
                    Height = 400,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
            }
        }

        private void DeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Supplier selectedSupplier)
            {
                var result = MessageBox.Show($"Xóa nhà cung cấp {selectedSupplier.Name}?", "Xác nhận xóa",
                                             MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        context.Suppliers.Remove(selectedSupplier);
                        context.SaveChanges();
                        Suppliers.Remove(selectedSupplier);
                        lvSupplier.ItemsSource = null;
                        lvSupplier.ItemsSource = Suppliers; // Refresh ListView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void SearchSupplier()
        {
            if (Suppliers == null)
            {
                lvSupplier.ItemsSource = null;
                return;
            }

            string keyword = SearchTextBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                lvSupplier.ItemsSource = Suppliers;
            }
            else
            {
                var filtered = Suppliers.Where(sup =>
                    (!string.IsNullOrEmpty(sup.Name) && sup.Name.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(sup.Phone) && sup.Phone.Contains(keyword))
                ).ToList();
                lvSupplier.ItemsSource = filtered;
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchSupplier();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchSupplier();
        }
    }
}

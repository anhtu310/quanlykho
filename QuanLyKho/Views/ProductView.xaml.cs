using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class ProductView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Product> Products { get; set; }

        public ProductView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            LoadData();
        }

        private void LoadData()
        {
            Dispatcher.Invoke(() =>
            {
                var list = context.Products
                    .Include(p => p.IdSupplierNavigation)
                    .Include(p => p.IdUnitNavigation)
                    .AsNoTracking()
                    .ToList();

                Products = new ObservableCollection<Product>(list);
                lvProduct.ItemsSource = Products;
            });
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProductForm();
            form.OnProductUpdated = LoadData;
            var window = new Window
            {
                Content = form,
                Title = "Thêm sản phẩm",
                Width = 350,
                Height = 350,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchProduct();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchProduct();
            }
        }

        private void SearchProduct()
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                lvProduct.ItemsSource = Products;
            }
            else
            {
                var filtered = Products.Where(prod =>
                    (!string.IsNullOrEmpty(prod.Name) && prod.Name.ToLower().Contains(keyword))
                ).ToList();

                lvProduct.ItemsSource = filtered;
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Product selectedProduct)
            {
                var form = new ProductForm(selectedProduct);
                form.OnProductUpdated = LoadData;
                var window = new Window
                {
                    Content = form,
                    Title = "Chỉnh sửa sản phẩm",
                    Width = 350,
                    Height = 350,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
                LoadData();
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)?.DataContext is Product selectedProduct)
            {
                var result = MessageBox.Show($"Xóa sản phẩm {selectedProduct.Name}?", "Xác nhận xóa",
                                             MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        context.Products.Remove(selectedProduct);
                        context.SaveChanges();

                        Products.Remove(selectedProduct);
                        lvProduct.ItemsSource = null;
                        lvProduct.ItemsSource = Products;
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
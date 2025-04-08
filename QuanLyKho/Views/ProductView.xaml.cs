using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class ProductView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Product>? Products { get; set; }
        public ObservableCollection<ProductSupplier>? ProductSuppliers { get; set; }

        public ProductView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            LoadData();
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProduct.SelectedItem is Product selectedProduct)
            {
                // Lấy danh sách nhà cung cấp của sản phẩm
                var productSuppliers = context.ProductSuppliers
                    .Where(ps => ps.IdProduct == selectedProduct.Id)
                    .Include(ps => ps.IdSupplierNavigation)  // Lấy thông tin nhà cung cấp
                    .Include(ps => ps.InputInfos)  // Lấy thông tin nhập hàng từ InputInfo
                    .ThenInclude(ii => ii.IdInputNavigation) // Lấy thông tin phiếu nhập hàng
                    .AsNoTracking()
                    .ToList();

                // Lấy danh sách nhà cung cấp và thông tin nhập
                var supplierData = productSuppliers
                    .SelectMany(ps => ps.InputInfos
                        .Where(ii => ii.Status == "Hoàn thành")  // Thêm điều kiện lọc trạng thái
                        .Select(ii => new
                        {
                            SupplierEmail = ps.IdSupplierNavigation.Email,
                            SupplierName = ps.IdSupplierNavigation.Name,
                            SupplierAddress = ps.IdSupplierNavigation.Address,
                            SupplierPhone = ps.IdSupplierNavigation.Phone,
                            Count = ii.Count,
                            InputPrice = ii.InputPrice,
                            DateInput = ii.IdInputNavigation.DateInput.ToString("dd/MM/yyyy")
                        }))
                    .ToList();

                // Gán dữ liệu nhà cung cấp vào ListView
                lvSuppliers.ItemsSource = supplierData;
            }
            else
            {
                lvSuppliers.ItemsSource = null;
            }
        }


        private void LoadData()
        {
            Dispatcher.Invoke(() =>
            {
                // Load danh sách sản phẩm
                var productList = context.Products
                    .Include(p => p.Category) // Đảm bảo lấy danh mục sản phẩm
                    .Include(p => p.IdUnitNavigation) // Lấy thông tin đơn vị
                    .Include(p => p.ProductSuppliers) // Lấy danh sách nhà cung cấp
                    .ThenInclude(ps => ps.IdSupplierNavigation) // Lấy thông tin nhà cung cấp
                    .AsNoTracking()
                    .ToList();

                Products = new ObservableCollection<Product>(productList);
                lvProduct.ItemsSource = Products;

                // Load danh sách nhà cung cấp
                var supplierList = context.ProductSuppliers
                    .Include(ps => ps.IdSupplierNavigation) // Lấy thông tin nhà cung cấp
                    .Include(ps => ps.IdProductNavigation) // Lấy thông tin sản phẩm
                    .AsNoTracking()
                    .ToList();

                ProductSuppliers = new ObservableCollection<ProductSupplier>(supplierList);
                lvSuppliers.ItemsSource = ProductSuppliers; // Gán danh sách nhà cung cấp vào ListView
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
                var filtered = Products?.Where(prod =>
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
            if ((sender as Button)?.DataContext is not Product selectedProduct)
                return;

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{selectedProduct.Name}'?",
                "Xác nhận xóa",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmResult != MessageBoxResult.Yes)
                return;

            using var transaction = context.Database.BeginTransaction();
            try
            {

                var productToDelete = context.Products
                    .Where(p => p.Id == selectedProduct.Id)
                    .Select(p => new
                    {
                        Product = p,
                        SupplierIds = p.ProductSuppliers.Select(ps => ps.Id).ToList(),
                        OutputInfoIds = p.OutputInfos.Select(oi => oi.Id).ToList()
                    })
                    .FirstOrDefault();

                if (productToDelete == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (productToDelete.OutputInfoIds.Any())
                {
                    context.OutputInfos.Where(oi => productToDelete.OutputInfoIds.Contains(oi.Id)).ExecuteDelete();
                }

                if (productToDelete.SupplierIds.Any())
                {
                    context.InputInfos.Where(ii => productToDelete.SupplierIds.Contains(ii.IdProductSupplier)).ExecuteDelete();
                    context.ProductSuppliers.Where(ps => productToDelete.SupplierIds.Contains(ps.Id)).ExecuteDelete();
                }

                context.Products.Where(p => p.Id == selectedProduct.Id).ExecuteDelete();

                context.SaveChanges();
                transaction.Commit();

                Products.Remove(selectedProduct);
                MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
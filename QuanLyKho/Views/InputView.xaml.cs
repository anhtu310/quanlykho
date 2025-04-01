using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Data;
using QuanLyKho.Helpers;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class InputView : UserControl
    {
        private QuanlyKhoDbContext _context;

        public InputView()
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            LoadInputs();
        }

        private void LoadInputs()
        {
            lvInput.ItemsSource = _context.Inputs.ToList();
            lvInputInfo.ItemsSource = null;
        }

        private void SearchInputs()
        {
            string keyword = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadInputs();
                return;
            }

            if (DateTime.TryParse(keyword, out DateTime searchDate))
            {
                lvInput.ItemsSource = _context.Inputs
                    .Where(i => i.DateInput == searchDate.Date)
                    .ToList();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ngày hợp lệ (YYYY-MM-DD)", "Lỗi tìm kiếm", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchInputs();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchInputs();
        }

        private void lvInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvInput.SelectedItem is Input selectedInput)
            {
                var inputInfos = _context.InputInfos
                    .Where(ii => ii.IdInput == selectedInput.Id)
                    .Include(ii => ii.IdProductSupplierNavigation)
                    .Select(ii => new
                    {
                        ii.Id,
                        ProductName = ii.IdProductSupplierNavigation.IdProductNavigation.Name,
                        Supplier = ii.IdProductSupplierNavigation.IdSupplierNavigation.Name,
                        ii.Count,
                        ii.InputPrice,
                        ii.OutputPrice,
                        ii.Status,
                        ImageSource = ImageHelper.ConvertToImageSource(ii.ContractImage),
                        ContractImage = ii.ContractImage // Thêm trường này để có thể truy cập sau
                    })
                    .ToList();

                lvInputInfo.ItemsSource = inputInfos;
            }
        }

        private void ViewContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext != null)
            {
                try
                {
                    dynamic data = button.DataContext;
                    byte[] contractImage = data.ContractImage;

                    if (contractImage != null && contractImage.Length > 0)
                    {
                        var imageSource = ImageHelper.ConvertToImageSource(contractImage);
                        ZoomedImage.Source = imageSource;

                        // Đặt vị trí popup
                        ImagePopup.Placement = PlacementMode.Center;
                        ImagePopup.PlacementTarget = this; // Đặt target là UserControl hiện tại
                        ImagePopup.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có ảnh hợp đồng để hiển thị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị hợp đồng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            ImagePopup.IsOpen = false;
        }

        private void AddInput_Click(object sender, RoutedEventArgs e)
        {
            var newInput = new Input
            {
                DateInput = DateTime.Now
            };

            _context.Inputs.Add(newInput);
            _context.SaveChanges();

            LoadInputs();
            MessageBox.Show("Thêm mới phiếu nhập thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteInput_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var inputToDelete = button?.DataContext as Input;

            if (inputToDelete != null)
            {
                var hasDetails = _context.InputInfos.Any(ii => ii.IdInput == inputToDelete.Id);

                if (hasDetails)
                {
                    MessageBox.Show("Không thể xóa phiếu nhập đã có chi tiết!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.Inputs.Remove(inputToDelete);
                        _context.SaveChanges();
                        LoadInputs();
                        MessageBox.Show("Đã xóa phiếu nhập thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void AddInputInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lvInput.SelectedItem is Input selectedInput)
            {
                var form = new InputInfoForm(selectedInput.Id);
                form.OnInputInfoUpdated = () =>
                {
                    LoadInputs();
                    lvInput_SelectionChanged(null, null);
                };

                var window = new Window
                {
                    Content = form,
                    Title = "Thêm thông tin phiếu nhập",
                    Width = 400,
                    Height = 600,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
            }
        }

        private void EditInputInfo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is object selectedRow)
            {
                var property = selectedRow.GetType().GetProperty("Id");
                if (property != null)
                {
                    int? id = property.GetValue(selectedRow) as int?;
                    if (id.HasValue)
                    {
                        var selectedInputInfo = _context.InputInfos
                            .Include(ii => ii.IdProductSupplierNavigation)
                            .ThenInclude(ps => ps.IdProductNavigation)
                            .Include(ii => ii.IdProductSupplierNavigation)
                            .ThenInclude(ps => ps.IdSupplierNavigation)
                            .FirstOrDefault(ii => ii.Id == id.Value);

                        if (selectedInputInfo != null)
                        {
                            var form = new InputInfoForm(selectedInputInfo);
                            form.OnInputInfoUpdated = () =>
                            {
                                LoadInputs();
                                lvInput_SelectionChanged(null, null);
                            };

                            var window = new Window
                            {
                                Content = form,
                                Title = "Chỉnh sửa thông tin phiếu nhập",
                                Width = 400,
                                Height = 600,
                                WindowStartupLocation = WindowStartupLocation.CenterScreen
                            };
                            window.ShowDialog();
                        }
                    }
                }
            }
        }

        private void DeleteInputInfo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is object selectedRow)
            {
                var property = selectedRow.GetType().GetProperty("Id");
                if (property != null)
                {
                    int? id = property.GetValue(selectedRow) as int?;
                    if (id.HasValue)
                    {
                        // Load đầy đủ thông tin InputInfo kèm các navigation properties cần thiết
                        var selectedInputInfo = _context.InputInfos
                            .Include(ii => ii.IdProductSupplierNavigation)
                                .ThenInclude(ps => ps.IdProductNavigation)
                            .Include(ii => ii.IdProductSupplierNavigation)
                                .ThenInclude(ps => ps.IdSupplierNavigation)
                            .FirstOrDefault(ii => ii.Id == id.Value);

                        if (selectedInputInfo != null)
                        {
                            var result = MessageBox.Show(
                                $"Bạn có chắc chắn muốn xóa thông tin nhập hàng này?\n\n" +
                                $"Sản phẩm: {selectedInputInfo.IdProductSupplierNavigation.IdProductNavigation.Name}\n" +
                                $"Nhà cung cấp: {selectedInputInfo.IdProductSupplierNavigation.IdSupplierNavigation.Name}\n" +
                                $"Số lượng: {selectedInputInfo.Count}",
                                "Xác nhận xóa",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    // 1. Xử lý cập nhật số lượng sản phẩm
                                    var product = selectedInputInfo.IdProductSupplierNavigation.IdProductNavigation;
                                    var supplier = selectedInputInfo.IdProductSupplierNavigation.IdSupplierNavigation;

                                    if (selectedInputInfo.Status == "Hoàn thành")
                                    {
                                        // Giảm số lượng sản phẩm trong kho
                                        product.Quantity -= selectedInputInfo.Count;
                                        if (product.Quantity < 0) product.Quantity = 0;

                                        // Có thể thêm logic cập nhật thông tin nhà cung cấp nếu cần
                                        // Ví dụ: supplier.TotalImports -= selectedInputInfo.Count;

                                        _context.Products.Update(product);
                                        _context.Suppliers.Update(supplier);
                                    }

                                    // 2. Xóa các OutputInfo liên quan (nếu có)
                                    var relatedOutputInfos = _context.OutputInfos
                                        .Where(oi => oi.IdInputInfo == selectedInputInfo.Id)
                                        .ToList();

                                    if (relatedOutputInfos.Any())
                                    {
                                        _context.OutputInfos.RemoveRange(relatedOutputInfos);
                                    }

                                    // 3. Xóa InputInfo
                                    _context.InputInfos.Remove(selectedInputInfo);
                                    _context.SaveChanges();

                                    MessageBox.Show(
                                        $"Đã xóa thông tin nhập hàng thành công!\n\n" +
                                        $"Sản phẩm: {product.Name}\n" +
                                        $"Số lượng đã trừ: {selectedInputInfo.Count}",
                                        "Thành công",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                                    // Cập nhật lại giao diện
                                    LoadInputs();
                                    lvInput_SelectionChanged(null, null);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(
                                        $"Lỗi khi xóa thông tin nhập hàng: {ex.Message}\n\n" +
                                        $"Chi tiết: {ex.InnerException?.Message}",
                                        "Lỗi",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
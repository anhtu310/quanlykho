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
    public partial class OutputView : UserControl
    {
        private QuanlyKhoDbContext _context;

        public OutputView()
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            LoadOutputs();
        }

        private void LoadOutputs()
        {
            lvOutput.ItemsSource = _context.Outputs.ToList();
            lvOutputInfo.ItemsSource = null;
            FilterButton_Click(null, null);
        }

        private void lvOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvOutput.SelectedItem is Output selectedOutput)
            {
                var outputInfos = _context.OutputInfos
                    .Where(oi => oi.IdOutput == selectedOutput.Id)
                    .Include(oi => oi.IdInputInfoNavigation)
                        .ThenInclude(ii => ii.IdProductSupplierNavigation)
                            .ThenInclude(ps => ps.IdProductNavigation)
                    .Include(oi => oi.IdInputInfoNavigation)
                        .ThenInclude(ii => ii.IdProductSupplierNavigation)
                            .ThenInclude(ps => ps.IdSupplierNavigation)
                    .Include(oi => oi.IdCustomerNavigation)
                    .Select(oi => new
                    {
                        oi.Id,
                        ProductName = oi.IdInputInfoNavigation.IdProductSupplierNavigation.IdProductNavigation.Name,
                        Customer = oi.IdCustomerNavigation.Name,
                        oi.Count,
                        oi.OutputPrice,
                        oi.Status,
                        ImageSource = ImageHelper.ConvertToImageSource(oi.ContractImage),
                        InvoiceImage = oi.ContractImage
                    })
                    .ToList();

                lvOutputInfo.ItemsSource = outputInfos;
            }
        }

        private void ViewInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext != null)
            {
                try
                {
                    dynamic data = button.DataContext;
                    byte[] invoiceImage = data.ContractImage;

                    if (invoiceImage != null && invoiceImage.Length > 0)
                    {
                        var imageSource = ImageHelper.ConvertToImageSource(invoiceImage);
                        ZoomedImage.Source = imageSource;

                        ImagePopup.Placement = PlacementMode.Center;
                        ImagePopup.PlacementTarget = this;
                        ImagePopup.IsOpen = true;
                    }
                    else
                    {
                        MessageBox.Show("Không có ảnh hóa đơn để hiển thị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị hóa đơn: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            ImagePopup.IsOpen = false;
        }

        private void AddOutput_Click(object sender, RoutedEventArgs e)
        {
            var newOutput = new Output
            {
                DateOutput = DateTime.Now
            };

            _context.Outputs.Add(newOutput);
            _context.SaveChanges();

            LoadOutputs();
            MessageBox.Show("Thêm mới phiếu xuất thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteOutput_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var outputToDelete = button?.DataContext as Output;

            if (outputToDelete != null)
            {
                var hasDetails = _context.OutputInfos.Any(oi => oi.IdOutput == outputToDelete.Id);

                if (hasDetails)
                {
                    MessageBox.Show("Không thể xóa phiếu xuất đã có chi tiết!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu xuất này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _context.Outputs.Remove(outputToDelete);
                        _context.SaveChanges();
                        LoadOutputs();
                        MessageBox.Show("Đã xóa phiếu xuất thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void AddOutputInfo_Click(object sender, RoutedEventArgs e)
        {
            if (lvOutput.SelectedItem is Output selectedOutput)
            {
                ShowOutputInfoForm(
                    outputId: selectedOutput.Id,
                    title: "Thêm thông tin phiếu xuất");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu xuất trước khi thêm thông tin",
                               "Cảnh báo",
                               MessageBoxButton.OK,
                               MessageBoxImage.Warning);
            }
        }

        private void EditOutputInfo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext != null)
            {
                try
                {
                    dynamic data = button.DataContext;
                    int id = data.Id;

                    var outputInfo = _context.OutputInfos
                        .Include(oi => oi.IdInputInfoNavigation)
                        .ThenInclude(ii => ii.IdProductSupplierNavigation)
                        .ThenInclude(ps => ps.IdProductNavigation)
                        .Include(oi => oi.IdInputInfoNavigation)
                        .ThenInclude(ii => ii.IdProductSupplierNavigation)
                        .ThenInclude(ps => ps.IdSupplierNavigation)
                        .Include(oi => oi.IdCustomerNavigation)
                        .FirstOrDefault(oi => oi.Id == id);

                    if (outputInfo != null)
                    {
                        ShowOutputInfoForm(
                            outputInfo: outputInfo,
                            title: "Chỉnh sửa thông tin phiếu xuất");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi mở form chỉnh sửa: {ex.Message}",
                                  "Lỗi",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Error);
                }
            }
        }

        private void ShowOutputInfoForm(int? outputId = null, OutputInfo outputInfo = null, string title = "")
        {
            OutputInfoForm form = outputId != null
                ? new OutputInfoForm(outputId.Value)
                : new OutputInfoForm(outputInfo);

            form.OnOutputInfoUpdated = () =>
            {
                LoadOutputs();
                lvOutput_SelectionChanged(null, null);
            };

            var window = new Window
            {
                Content = form,
                Title = title,
                Width = 500,
                Height = 600,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
        }
        private void DeleteOutputInfo_Click(object sender, RoutedEventArgs e)
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
                        var selectedOutputInfo = _context.OutputInfos
                            .Include(oi => oi.IdInputInfoNavigation)
                                .ThenInclude(ii => ii.IdProductSupplierNavigation)
                                    .ThenInclude(ps => ps.IdProductNavigation)
                            .Include(oi => oi.IdCustomerNavigation)
                            .FirstOrDefault(oi => oi.Id == id.Value);

                        if (selectedOutputInfo != null)
                        {
                            var result = MessageBox.Show(
                                $"Bạn có chắc chắn muốn xóa thông tin xuất hàng này?\n\n" +
                                $"Sản phẩm: {selectedOutputInfo.IdInputInfoNavigation.IdProductSupplierNavigation.IdProductNavigation.Name}\n" +
                                $"Khách hàng: {selectedOutputInfo.IdCustomerNavigation.Name}\n" +
                                $"Số lượng: {selectedOutputInfo.Count}",
                                "Xác nhận xóa",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question);

                            if (result == MessageBoxResult.Yes)
                            {
                                try
                                {
                                    // 1. Xử lý cập nhật số lượng sản phẩm
                                    var product = selectedOutputInfo.IdInputInfoNavigation.IdProductSupplierNavigation.IdProductNavigation;
                                    var customer = selectedOutputInfo.IdCustomerNavigation;

                                    if (selectedOutputInfo.Status == "Hoàn thành")
                                    {
                                        // Tăng số lượng sản phẩm trong kho (hoàn trả)
                                        product.Quantity += selectedOutputInfo.Count;

                                        _context.Products.Update(product);
                                        _context.Customers.Update(customer);
                                    }

                                    // 2. Xóa OutputInfo
                                    _context.OutputInfos.Remove(selectedOutputInfo);
                                    _context.SaveChanges();

                                    MessageBox.Show(
                                        $"Đã xóa thông tin xuất hàng thành công!\n\n" +
                                        $"Sản phẩm: {product.Name}\n" +
                                        $"Số lượng đã hoàn trả: {selectedOutputInfo.Count}",
                                        "Thành công",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                                    // Cập nhật lại giao diện
                                    LoadOutputs();
                                    lvOutput_SelectionChanged(null, null);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(
                                        $"Lỗi khi xóa thông tin xuất hàng: {ex.Message}\n\n" +
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

        private void FilterOutputs(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var query = _context.Outputs.AsQueryable();

                if (startDate.HasValue)
                    query = query.Where(o => o.DateOutput >= startDate.Value.Date);

                if (endDate.HasValue)
                    query = query.Where(o => o.DateOutput <= endDate.Value.Date.AddDays(1).AddTicks(-1));

                var filteredOutputs = query.ToList();
                lvOutput.ItemsSource = filteredOutputs;

                if (filteredOutputs.Count > 0)
                {
                    lvOutput.SelectedItem = filteredOutputs.First();
                }
                else
                {
                    lvOutputInfo.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = dpStartDate.SelectedDate;
            DateTime? endDate = dpEndDate.SelectedDate;

            if (startDate.HasValue && endDate.HasValue && startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            FilterOutputs(startDate, endDate);
        }
    }
}
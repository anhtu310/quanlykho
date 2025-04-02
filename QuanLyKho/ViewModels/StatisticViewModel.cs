using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ClosedXML.Excel;
using Microsoft.Win32;
using QuanLyKho.Data;
using QuanLyKho.Models;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyKho.Helpers;

namespace QuanLyKho.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private ObservableCollection<StatisticsItem> _statisticsData;
        private ChartValues<int> _importData;
        private ChartValues<int> _exportData;
        private ChartValues<decimal> _revenueData;
        private string[] _productLabels;

        public DateTime? FromDate
        {
            get => _fromDate;
            set
            {
                _fromDate = value;
                OnPropertyChanged();
                LoadData();
            }
        }

        public DateTime? ToDate
        {
            get => _toDate;
            set
            {
                _toDate = value;
                OnPropertyChanged();
                LoadData();
            }
        }

        public ObservableCollection<StatisticsItem> StatisticsData
        {
            get => _statisticsData;
            set
            {
                _statisticsData = value;
                OnPropertyChanged();
            }
        }

        public ChartValues<int> ImportData
        {
            get => _importData;
            set
            {
                _importData = value;
                OnPropertyChanged();
            }
        }

        public ChartValues<int> ExportData
        {
            get => _exportData;
            set
            {
                _exportData = value;
                OnPropertyChanged();
            }
        }

        public ChartValues<decimal> RevenueData
        {
            get => _revenueData;
            set
            {
                _revenueData = value;
                OnPropertyChanged();
            }
        }

        public string[] ProductLabels
        {
            get => _productLabels;
            set
            {
                _productLabels = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadDataCommand { get; }
        public ICommand ExportToExcelCommand { get; }

        public StatisticsViewModel()
        {
            LoadDataCommand = new RelayCommand(_ => LoadData());
            ExportToExcelCommand = new RelayCommand(_ => ExportToExcel());
            StatisticsData = new ObservableCollection<StatisticsItem>();
            ImportData = new ChartValues<int>();
            ExportData = new ChartValues<int>();
            RevenueData = new ChartValues<decimal>();
            LoadData();
        }

        public void LoadData()
        {
            using (var context = new QuanlyKhoDbContext())
            {
                var query = context.Products
                    .Select(p => new StatisticsItem
                    {
                        ProductName = p.Name,
                        Inventory = p.Quantity,
                        ImportQuantity = context.InputInfos
                            .Where(i => i.IdProductSupplier == p.Id &&
                                        (FromDate == null || i.IdInputNavigation.DateInput >= FromDate) &&
                                        (ToDate == null || i.IdInputNavigation.DateInput <= ToDate))
                            .Sum(i => (int?)i.Count) ?? 0,
                        ExportQuantity = context.OutputInfos
                            .Where(o => o.IdProduct == p.Id &&
                                        (FromDate == null || o.IdOutputNavigation.DateOutput >= FromDate) &&
                                        (ToDate == null || o.IdOutputNavigation.DateOutput <= ToDate))
                            .Sum(o => (int?)o.Count) ?? 0,
                        Revenue = context.OutputInfos
                            .Where(o => o.IdProduct == p.Id &&
                                        (FromDate == null || o.IdOutputNavigation.DateOutput >= FromDate) &&
                                        (ToDate == null || o.IdOutputNavigation.DateOutput <= ToDate))
                            .Sum(o => (decimal?)(o.Count * o.IdInputInfoNavigation.OutputPrice)) ?? 0
                    }).ToList();

                StatisticsData.Clear();
                ImportData.Clear();
                ExportData.Clear();
                RevenueData.Clear();
                foreach (var item in query)
                {
                    StatisticsData.Add(item);
                    ImportData.Add(item.ImportQuantity);
                    ExportData.Add(item.ExportQuantity);
                    RevenueData.Add(item.Revenue);
                }

                ProductLabels = query.Select(item => item.ProductName).ToArray();
            }
        }

        private void ExportToExcel()
        {
            if (StatisticsData == null || StatisticsData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"ThongKeKhoHang_{DateTime.Now:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Thống kê kho hàng");
                        worksheet.Cell(1, 1).Value = "Tên Sản Phẩm";
                        worksheet.Cell(1, 2).Value = "Tồn Kho";
                        worksheet.Cell(1, 3).Value = "Số Lượng Nhập";
                        worksheet.Cell(1, 4).Value = "Số Lượng Xuất";
                        worksheet.Cell(1, 5).Value = "Doanh Thu";

                        int row = 2;
                        foreach (var item in StatisticsData)
                        {
                            worksheet.Cell(row, 1).Value = item.ProductName;
                            worksheet.Cell(row, 2).Value = item.Inventory;
                            worksheet.Cell(row, 3).Value = item.ImportQuantity;
                            worksheet.Cell(row, 4).Value = item.ExportQuantity;
                            worksheet.Cell(row, 5).Value = item.Revenue;
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }

    public class StatisticsItem
    {
        public string ProductName { get; set; }
        public int Inventory { get; set; }
        public int ImportQuantity { get; set; }
        public int ExportQuantity { get; set; }
        public decimal Revenue { get; set; }
    }
}

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
    public partial class UnitView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Unit> Units { get; set; }

        public UnitView()
        {
            InitializeComponent();
            context = new QuanlyKhoDbContext();
            Units = new ObservableCollection<Unit>();
            loadData();
        }

        // Load danh sách đơn vị và danh mục
        private void loadData()
        {
            var unitList = context.Units.AsNoTracking().ToList();
            var categoryList = context.Categories.AsNoTracking().ToList();

            Units.Clear();

            foreach (var unit in unitList)
            {
                Units.Add(unit);
            }

            lvUnit.ItemsSource = Units;
        }

        // Thêm đơn vị mới
        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên đơn vị mới:", "Thêm đơn vị", "").Trim();
            if (string.IsNullOrWhiteSpace(newName)) return;

            bool exists = context.Units.Any(u => u.Name.ToLower() == newName.ToLower());
            if (exists)
            {
                MessageBox.Show("Tên đơn vị đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newUnit = new Unit { Name = newName };
                context.Units.Add(newUnit);
                context.SaveChanges();
                loadData();
                MessageBox.Show("Thêm đơn vị thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn vị: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Sửa đơn vị
        private void EditUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lvUnit.SelectedItem is Unit selectedUnit)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Sửa tên đơn vị:", "Chỉnh sửa đơn vị", selectedUnit.Name).Trim();

                if (string.IsNullOrWhiteSpace(newName)) return;

                bool exists = context.Units.Any(u => u.Id != selectedUnit.Id && u.Name.ToLower() == newName.ToLower());
                if (exists)
                {
                    MessageBox.Show("Tên đơn vị đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    var unitToUpdate = context.Units.FirstOrDefault(u => u.Id == selectedUnit.Id);
                    if (unitToUpdate != null)
                    {
                        unitToUpdate.Name = newName;
                        context.SaveChanges();
                        loadData();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn vị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật đơn vị: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // Xóa đơn vị
        private void DeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lvUnit.SelectedItem is Unit selectedUnit)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa đơn vị này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var unitToDelete = context.Units.FirstOrDefault(u => u.Id == selectedUnit.Id);
                        if (unitToDelete != null)
                        {
                            context.Units.Remove(unitToDelete);
                            context.SaveChanges();
                            loadData();
                            MessageBox.Show("Xóa đơn vị thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy đơn vị!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa đơn vị: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

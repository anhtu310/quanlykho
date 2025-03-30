using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using QuanLyKho.Models;
using Microsoft.EntityFrameworkCore;

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

        private void loadData()
        {
            var list = context.Units.AsNoTracking().ToList();
            Units.Clear();
            foreach (var item in list)
            {
                Units.Add(item);
            }
            lvUnit.ItemsSource = Units;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Kiểm tra nếu nhấn Enter
            {
                string keyword = SearchTextBox.Text.Trim().ToLower();
                var filteredList = context.Units
                                          .AsNoTracking()
                                          .Where(u => u.Name.ToLower().Contains(keyword))
                                          .ToList();

                Units.Clear();
                foreach (var item in filteredList)
                {
                    Units.Add(item);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim().ToLower();
            var filteredList = context.Units
                                      .AsNoTracking()
                                      .Where(u => u.Name.ToLower().Contains(keyword))
                                      .ToList();

            Units.Clear();
            foreach (var item in filteredList)
            {
                Units.Add(item);
            }
        }

        // Thêm đơn vị mới với kiểm tra trùng tên
        private void AddUnit_Click(object sender, RoutedEventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên đơn vị mới:", "Thêm đơn vị", "").Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            // Kiểm tra trùng tên đơn vị
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

        // Chỉnh sửa đơn vị với kiểm tra trùng tên
        private void EditUnit_Click(object sender, RoutedEventArgs e)
        {
            if (lvUnit.SelectedItem is Unit selectedUnit)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Sửa tên đơn vị:", "Chỉnh sửa đơn vị", selectedUnit.Name).Trim();

                if (string.IsNullOrWhiteSpace(newName))
                {
                    return;
                }

                // Kiểm tra trùng tên (trừ chính bản ghi đang sửa)
                bool exists = context.Units.Any(u =>
                    u.Id != selectedUnit.Id &&
                    u.Name.ToLower() == newName.ToLower());

                if (exists)
                {
                    MessageBox.Show("Tên đơn vị đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    selectedUnit.Name = newName;
                    context.Units.Update(selectedUnit);
                    context.SaveChanges();
                    loadData();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    context.Units.Remove(selectedUnit);
                    context.SaveChanges();
                    loadData();
                    MessageBox.Show("Xóa đơn vị thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

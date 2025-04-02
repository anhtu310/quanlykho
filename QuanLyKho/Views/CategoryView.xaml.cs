using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    /// <summary>
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        private QuanlyKhoDbContext context;
        public ObservableCollection<Category> Categories { get; set; }
        public CategoryView()
        {
            InitializeComponent();
            this.context = new QuanlyKhoDbContext();
            Categories = new ObservableCollection<Category>();
            loadData();
        }

        private void loadData()
        {
            var unitList = context.Units.AsNoTracking().ToList();
            var categoryList = context.Categories.AsNoTracking().ToList();

            Categories.Clear();

            foreach (var category in categoryList)
            {
                Categories.Add(category);
            }

            lvCategory.ItemsSource = Categories;
        }
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            string newName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên danh mục mới:", "Thêm danh mục", "").Trim();
            if (string.IsNullOrWhiteSpace(newName)) return;

            bool exists = context.Categories.Any(c => c.Name.ToLower() == newName.ToLower());
            if (exists)
            {
                MessageBox.Show("Tên danh mục đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var newCategory = new Category { Name = newName };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                loadData();
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm danh mục: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategory.SelectedItem is Category selectedCategory)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Sửa tên danh mục:", "Chỉnh sửa danh mục", selectedCategory.Name).Trim();

                if (string.IsNullOrWhiteSpace(newName)) return;

                bool exists = context.Categories.Any(c => c.Id != selectedCategory.Id && c.Name.ToLower() == newName.ToLower());
                if (exists)
                {
                    MessageBox.Show("Tên danh mục đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    var categoryToUpdate = context.Categories.FirstOrDefault(c => c.Id == selectedCategory.Id);
                    if (categoryToUpdate != null)
                    {
                        categoryToUpdate.Name = newName;
                        context.SaveChanges();
                        loadData();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy danh mục!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật danh mục: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategory.SelectedItem is Category selectedCategory)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa danh mục này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var categoryToDelete = context.Categories.FirstOrDefault(c => c.Id == selectedCategory.Id);
                        if (categoryToDelete != null)
                        {
                            context.Categories.Remove(categoryToDelete);
                            context.SaveChanges();
                            loadData();
                            MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy danh mục!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

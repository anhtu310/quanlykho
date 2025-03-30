using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        }

        private void SearchInputs()
        {
            string keyword = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadInputs();  // Nếu không có từ khóa tìm kiếm, tải tất cả phiếu nhập
                return;
            }

            if (DateTime.TryParse(keyword, out DateTime searchDate))
            {
                // So sánh ngày mà không quan tâm giờ, phút, giây
                lvInput.ItemsSource = _context.Inputs
                    .Where(i => i.DateInput.Date == searchDate.Date)  // Chỉ so sánh ngày (không so sánh giờ)
                    .ToList();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ngày hợp lệ (YYYY-MM-DD)", "Lỗi tìm kiếm", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void SearchTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
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
                // Lấy danh sách các thông tin nhập
                var inputInfos = _context.InputInfos
                    .Where(ii => ii.IdInput == selectedInput.Id)
                    .Select(ii => new
                    {
                        ProductName = ii.IdProductNavigation != null ? ii.IdProductNavigation.Name : "Không có tên sản phẩm",
                        Supplier = ii.IdSupplierNavigation != null ? ii.IdSupplierNavigation.Name : "Không có nhà cung cấp",
                        ii.Count,
                        ii.InputPrice,
                        ii.OutputPrice,
                        ii.Status
                    })
                    .ToList();

                lvInputInfo.ItemsSource = inputInfos;
            }
        }


        private void AddInput_Click(object sender, RoutedEventArgs e)
        {
            // Tạo đối tượng Input mới
            var newInput = new Input
            {
                DateInput = DateTime.Now  // Lấy thời gian thực tại thời điểm nhấn nút
            };

            // Thêm đối tượng Input vào cơ sở dữ liệu và lưu
            _context.Inputs.Add(newInput);
            _context.SaveChanges();

            // Tải lại danh sách phiếu nhập để cập nhật giao diện
            LoadInputs();

            // Hiển thị thông báo thành công
            MessageBox.Show("Thêm mới phiếu nhập thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteInput_Click(object sender, RoutedEventArgs e)
        {
            // Lấy đối tượng Input từ nút nhấn
            var button = sender as Button;
            var inputToDelete = button?.DataContext as Input;

            if (inputToDelete != null)
            {
                // Kiểm tra xem phiếu nhập có chi tiết hay không
                var hasDetails = _context.InputInfos.Any(ii => ii.IdInput == inputToDelete.Id);

                if (hasDetails)
                {
                    // Nếu đã có chi tiết, không cho phép xóa và thông báo
                    MessageBox.Show("Không thể xóa phiếu nhập đã có chi tiết!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    // Hiển thị hộp thoại xác nhận trước khi xóa
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Nếu người dùng chọn Yes, tiến hành xóa phiếu nhập
                        _context.Inputs.Remove(inputToDelete);
                        _context.SaveChanges();

                        // Cập nhật lại danh sách phiếu nhập
                        LoadInputs();

                        MessageBox.Show("Đã xóa phiếu nhập thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Nếu người dùng chọn No, không làm gì và thoát
                        return;
                    }
                }
            }
        }

        private void AddInputInfo_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có Input nào được chọn không
            if (lvInput.SelectedItem is Input selectedInput)
            {
                // Truyền IdInput vào InputInfoForm để thêm thông tin chi tiết cho phiếu nhập
                var form = new InputInfoForm(selectedInput.Id);  // Truyền IdInput vào constructor của InputInfoForm
                form.OnInputInfoUpdated = () => LoadInputs();  // Cập nhật lại danh sách khi thêm thành công

                var window = new Window
                {
                    Content = form,
                    Title = "Thêm thông tin phiếu nhập",
                    Width = 400,
                    Height = 500,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
            }
        }


        private void EditInputInfo_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có thông tin chi tiết được chọn trong DataContext của nút nhấn không
            if ((sender as FrameworkElement)?.DataContext is InputInfo selectedInputInfo)
            {
                // Kiểm tra nếu đã chọn InputInfo để sửa
                MessageBox.Show("Sửa thông tin: " + selectedInputInfo.Id);  // Kiểm tra

                // Mở InputInfoForm với thông tin hiện tại của InputInfo
                var form = new InputInfoForm(selectedInputInfo);  // Tạo form với thông tin của InputInfo
                form.OnInputInfoUpdated = () => LoadInputs();  // Cập nhật lại danh sách khi chỉnh sửa thành công

                var window = new Window
                {
                    Content = form,
                    Title = "Chỉnh sửa thông tin phiếu nhập",
                    Width = 400,
                    Height = 500,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };
                window.ShowDialog();
            }
        }

    }
}

using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using QuanLyKho.Views;

namespace QuanLyKho.UserControlAT
{
    public partial class UserControlBarUC : UserControl
    {
        public UserControlBarUC()
        {
            InitializeComponent();
            ContentArea.Content = new ProductView();

        }

        private void MenuToggleButton_Click(object sender, RoutedEventArgs e)
        {
            OptionMenu.IsOpen = MenuToggleButton.IsChecked ?? false;
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở cửa sổ thống kê
            var statisticsWindow = new StatisticsWindow();
            statisticsWindow.Show();

            // Đóng popup menu
            OptionMenu.IsOpen = false;
            MenuToggleButton.IsChecked = false;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Xử lý đăng xuất
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
                                       MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Thực hiện đăng xuất
                var loginWindow = new LoginWindow();
                loginWindow.Show();

                // Đóng cửa sổ hiện tại
                Window.GetWindow(this)?.Close();
            }

            // Đóng popup menu
            OptionMenu.IsOpen = false;
            MenuToggleButton.IsChecked = false;
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new EmployeeView();
            txtTitle.Text = "Quản lý nhân viên";
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new SupplierView();
            txtTitle.Text = "Quản lý nhà cung cấp";
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CustomerView();
            txtTitle.Text = "Quản lý khách hàng";
        }

        private void btnObject_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ProductView();
            txtTitle.Text = "Quản lý sản phẩm";
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new InputView();
            txtTitle.Text = "Quản lý nhập kho";
        }

        private void btnOutput_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new OutputView();
            txtTitle.Text = "Quản lý xuất kho";
        }

        private void btnUnit_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UnitView();
            txtTitle.Text = "Quản lý đơn vị tính";
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CategoryView();
            txtTitle.Text = "Quản lý danh mục";
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow(); // Tạo cửa sổ đăng nhập mới
            loginWindow.Show(); // Hiển thị LoginWindow

            Window mainWindow = Window.GetWindow(this); // Lấy cửa sổ hiện tại (MainWindow)
            if (mainWindow != null)
            {
                mainWindow.Close(); // Đóng cửa sổ chính
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Normal;
                ((Button)sender).ToolTip = "Maximize Window";
                ((PackIcon)((Button)sender).Content).Kind = PackIconKind.WindowMaximize;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
                ((Button)sender).ToolTip = "Restore Window";
                ((PackIcon)((Button)sender).Content).Kind = PackIconKind.WindowRestore;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}

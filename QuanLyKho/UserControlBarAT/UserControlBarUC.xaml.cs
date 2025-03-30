using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Views;

namespace QuanLyKho.UserControlAT
{
    public partial class UserControlBarUC : UserControl
    {
        public UserControlBarUC()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new EmployeeView();
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new SupplierView();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CustomerView();
        }

        private void btnObject_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ProductView();
        }

        private void btnInput_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new InputView();
        }

        private void btnOutput_Click(object sender, RoutedEventArgs e)
        {
            // ContentArea.Content = new OutputView();
        }

        private void btnUnit_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new UnitView();
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
    }
}

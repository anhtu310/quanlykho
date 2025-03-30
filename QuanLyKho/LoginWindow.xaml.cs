using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace QuanLyKho
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username == "admin" && password == "123")
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Cancle(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

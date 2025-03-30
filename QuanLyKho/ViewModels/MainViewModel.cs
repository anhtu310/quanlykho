using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyKho.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public bool IsLoading { get; set; } =false;
        public MainViewModel()
        {
            if (!IsLoading)
            {
                IsLoading = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            }
        }
    }
}

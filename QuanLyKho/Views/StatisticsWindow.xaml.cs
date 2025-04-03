using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using QuanLyKho.Data;
using QuanLyKho.Models;
using QuanLyKho.ViewModels;

namespace QuanLyKho.Views
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            DataContext = new StatisticsViewModel();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                var button = sender as Button;
                if (button != null && button.Content is PackIcon icon)
                {
                    icon.Kind = PackIconKind.WindowMaximize;
                }
            }
            else
            {
                window.WindowState = WindowState.Maximized;
                ((Button)sender).ToolTip = "Restore Window";
                var button = sender as Button;
                if (button != null && button.Content is PackIcon icon)
                {
                    icon.Kind = PackIconKind.WindowRestore;
                }

            }
        }
    }

}
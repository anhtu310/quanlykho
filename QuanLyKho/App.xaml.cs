using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using QuanLyKho.Data;

namespace QuanLyKho
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new QuanlyKhoDbContext())
            {
                // Nếu chưa có file .db thì tạo luôn
                if (!File.Exists("database.db"))
                {
                    context.Database.EnsureCreated();
                }
            }
        }

    }
}

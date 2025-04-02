using System;
using System.Data.SqlClient;
using System.Windows;

namespace QuanLyKho
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Constructor của lớp App
        public App()
        {
            // Tạo cơ sở dữ liệu nếu chưa có
            CreateDatabaseIfNotExists();
        }

        private void CreateDatabaseIfNotExists()
        {
            try
            {
                // Kết nối tới SQL Server LocalDB
                using (var connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;"))
                {
                    connection.Open();

                    // Kiểm tra xem cơ sở dữ liệu đã tồn tại chưa, nếu chưa thì tạo mới
                    var checkDbCommand = new SqlCommand("IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanlyKho') CREATE DATABASE QuanlyKho;", connection);
                    checkDbCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

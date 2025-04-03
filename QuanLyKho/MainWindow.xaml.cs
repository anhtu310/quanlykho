using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using QuanLyKho.Data;
using QuanLyKho.Models;

namespace QuanLyKho
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _stockCheckTimer;
        private Storyboard _warningAnimation;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            // Timer kiểm tra tồn kho mỗi 10 giây (có thể điều chỉnh)
            _stockCheckTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            _stockCheckTimer.Tick += (s, e) => CheckStockWarnings();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeWarningAnimation(); // Khởi tạo hiệu ứng cảnh báo
            CheckStockWarnings();       // Kiểm tra ngay khi cửa sổ mở
            _stockCheckTimer.Start();    // Bật timer
        }

        // Khởi tạo hiệu ứng nhấp nháy cho nút cảnh báo
        private void InitializeWarningAnimation()
        {
            _warningAnimation = new Storyboard { RepeatBehavior = RepeatBehavior.Forever };

            // Hiệu ứng đổi màu chữ (đỏ ↔ đỏ đậm)
            var colorAnimation = new ColorAnimation
            {
                From = Colors.Red,
                To = Colors.DarkRed,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = true
            };
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Button.Foreground).(SolidColorBrush.Color)"));
            _warningAnimation.Children.Add(colorAnimation);

            // Hiệu ứng phóng to (scale)
            var scaleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.2,
                Duration = TimeSpan.FromSeconds(0.5),
                AutoReverse = true
            };
            Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleY"));
            _warningAnimation.Children.Add(scaleAnimation);

            // Thiết lập RenderTransform
            btnWarning.RenderTransformOrigin = new Point(0.5, 0.5);
            btnWarning.RenderTransform = new ScaleTransform();
        }

        // Kiểm tra sản phẩm sắp hết hàng
        private void CheckStockWarnings()
        {
            try
            {
                using var context = new QuanlyKhoDbContext();
                var lowStockProducts = context.GetLowStockProducts();
                Dispatcher.Invoke(() => UpdateWarningIndicator(lowStockProducts)); // Đảm bảo chạy trên UI thread
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra tồn kho: {ex.Message}");
            }
        }

        // Cập nhật trạng thái cảnh báo
        private void UpdateWarningIndicator(List<Product> lowStockProducts)
        {
            bool hasWarning = lowStockProducts.Any();
            btnWarning.Visibility = hasWarning ? Visibility.Visible : Visibility.Collapsed;

            // Không cần quản lý Storyboard trong code-behind nữa
            if (!hasWarning)
            {
                btnWarning.Foreground = new SolidColorBrush(Colors.Red);
                btnWarning.RenderTransform = new TranslateTransform { Y = -30 };
            }
        }

        // Hiển thị popup cảnh báo khi nhấn nút
        private void btnWarning_Click(object sender, RoutedEventArgs e)
        {
            ShowStockWarningPopup();
        }

        // Tạo thông báo chi tiết
        private void ShowStockWarningPopup()
        {
            using var context = new QuanlyKhoDbContext();
            var lowStockProducts = context.GetLowStockProducts();

            if (!lowStockProducts.Any())
            {
                MessageBox.Show("Không có sản phẩm nào sắp hết hàng.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var message = new StringBuilder();
            message.AppendLine("⚠️ CẢNH BÁO: Các sản phẩm sắp hết hàng:");

            foreach (var product in lowStockProducts)
            {
                message.AppendLine($"- {product.Name}: {product.Quantity} (Cảnh báo ≤ {product.WarningQuantity})");
            }

            MessageBox.Show(message.ToString(), "Cảnh báo tồn kho", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void UpdateProductQuantity(int productId, int newQuantity)
        {
            using var context = new QuanlyKhoDbContext();
            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Quantity = newQuantity;
                context.SaveChanges();
                CheckStockWarnings();
            }
        }
    }
}
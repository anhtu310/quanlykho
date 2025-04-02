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

            _stockCheckTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(30)
            };
            _stockCheckTimer.Tick += (s, e) => CheckStockWarnings();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Khởi tạo animation
            InitializeWarningAnimation();

            CheckStockWarnings();
            _stockCheckTimer.Start();
        }

        private void InitializeWarningAnimation()
        {
            // Tạo storyboard cho hiệu ứng nhấp nháy
            _warningAnimation = new Storyboard();
            _warningAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Animation thay đổi màu sắc
            var colorAnimation = new ColorAnimation
            {
                From = Colors.Red,
                To = Colors.DarkRed,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Button.Foreground).(SolidColorBrush.Color)"));
            _warningAnimation.Children.Add(colorAnimation);

            // Animation thay đổi kích thước
            var scaleAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.2,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true
            };
            Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(scaleAnimation, new PropertyPath("RenderTransform.ScaleY"));
            _warningAnimation.Children.Add(scaleAnimation);

            // Áp dụng RenderTransform cho button
            btnWarning.RenderTransformOrigin = new Point(0.5, 0.5);
            btnWarning.RenderTransform = new ScaleTransform();
        }

        private void CheckStockWarnings()
        {
            using var context = new QuanlyKhoDbContext();
            var lowStockProducts = context.GetLowStockProducts();

            UpdateWarningIndicator(lowStockProducts);
        }

        private void UpdateWarningIndicator(List<Product> lowStockProducts)
        {
            bool hasWarning = lowStockProducts.Any();

            btnWarning.Visibility = hasWarning ? Visibility.Visible : Visibility.Collapsed;

            // Bật/tắt animation dựa trên trạng thái cảnh báo
            if (hasWarning)
            {
                _warningAnimation.Begin(btnWarning, true);
            }
            else
            {
                _warningAnimation.Stop(btnWarning);

                // Reset về trạng thái ban đầu
                btnWarning.Foreground = new SolidColorBrush(Colors.Red);
                if (btnWarning.RenderTransform is ScaleTransform scaleTransform)
                {
                    scaleTransform.ScaleX = 1.0;
                    scaleTransform.ScaleY = 1.0;
                }
            }
        }

        private void btnWarning_Click(object sender, RoutedEventArgs e)
        {
            ShowStockWarningPopup();
        }

        private void ShowStockWarningPopup()
        {
            using var context = new QuanlyKhoDbContext();
            var lowStockProducts = context.GetLowStockProducts();

            if (!lowStockProducts.Any()) return;

            var message = new StringBuilder();
            message.AppendLine("CẢNH BÁO: Các sản phẩm sắp hết hàng:");

            foreach (var product in lowStockProducts)
            {
                message.AppendLine($"- {product.Name}: {product.Quantity} (Cảnh báo ≤ {product.WarningQuantity})");
            }

            MessageBox.Show(message.ToString(),
                          "Cảnh báo tồn kho",
                          MessageBoxButton.OK,
                          MessageBoxImage.Warning);
        }
    }
}
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QuanLyKho.Helpers
{
    public static class ImageHelper
    {
        public static ImageSource ConvertToImageSource(byte[]? imageData)
        {
            if (imageData is { Length: > 0 }) // Kiểm tra null và độ dài ảnh
            {
                try
                {
                    using MemoryStream ms = new MemoryStream(imageData);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze(); // Cải thiện hiệu suất
                    return bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi hiển thị ảnh: {ex.Message}");
                }
            }

            // Nếu không có ảnh, tạo ảnh trống thay vì dùng đường dẫn
            return CreateEmptyImage();
        }

        private static ImageSource CreateEmptyImage()
        {
            int width = 100, height = 100; // Kích thước ảnh trống
            WriteableBitmap emptyBitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Rgb24, null);
            return emptyBitmap;
        }
    }
}

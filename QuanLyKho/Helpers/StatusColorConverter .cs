using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QuanLyKho.Helpers
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool status = (bool)value;
            return status ? Brushes.Green : Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

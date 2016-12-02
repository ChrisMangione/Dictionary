using System;
using System.Globalization;
using System.Windows.Data;

namespace Dictionary.Views
{
    class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            return !val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (bool)value;
            return !val;
        }
    }
}

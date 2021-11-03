using System;
using System.Globalization;
using System.Windows.Data;

namespace desaccordeVues.converters
{
    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int columnsCount = System.Convert.ToInt32(parameter);
            double width = (double)value;
            return width / columnsCount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

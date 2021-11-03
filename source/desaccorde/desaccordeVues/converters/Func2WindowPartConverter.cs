using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace desaccordeVues.converters
{
    class Func2WindowPartConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Func<UserControl> windowPartCreator)
            {
                return null;
            }
            return windowPartCreator();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

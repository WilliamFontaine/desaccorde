using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace desaccordeVues.converters
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DateTime date)
            {
                return null;
            }
            else if (date.Year == DateTime.Now.Year)
            //else if (date - DateTime.Now <= DateTime.Now)
            {
                return "New";
            }
            else return $"{date.Day} {date.Month} {date.Year}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace desaccordeVues.converters
{
    class String2ImageConverterUtilisateur : IValueConverter
    {
        public static string ImagesPath { get; private set; }

        static String2ImageConverterUtilisateur()
        {
            ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\images\\");
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageName = value as string;

            if (string.IsNullOrWhiteSpace(imageName)) return null;

            string imagePath = Path.Combine(ImagesPath, imageName);

            return new Uri(imagePath, UriKind.RelativeOrAbsolute);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

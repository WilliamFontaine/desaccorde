using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace desaccordeVues.converters
{
    class String2ImageConverter : IValueConverter
    {
#pragma warning disable IDE0044 // Ajouter un modificateur readonly
        static string ImagesPath;
#pragma warning restore IDE0044 // Ajouter un modificateur readonly

        static String2ImageConverter()
        {
            ImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "\\ImagesMusiques\\");
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

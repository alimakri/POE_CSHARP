using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace I_Converter
{
    public class CombineColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb(255, (byte)values[0], (byte)values[1], (byte)values[2]));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

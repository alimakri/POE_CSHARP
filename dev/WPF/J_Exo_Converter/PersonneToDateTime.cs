using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace J_Exo_Converter
{
    public class PersonneDetail : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var p = (PersonneViewModel) value;
            switch ((string)parameter)
            {
                case "Nom": return p.Nom;
                case "DateN": return p.DateNaissance.ToString("d MMMM yyyy");
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

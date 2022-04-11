using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using TSF_Models;

namespace TSF
{
    class TSF_PseudoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Personnage perso = value as Personnage;
            if (perso == null) return null;
            return $"{perso.Nom}, alias {perso.Pseudo}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

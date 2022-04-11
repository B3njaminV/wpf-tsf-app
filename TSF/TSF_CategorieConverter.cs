using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using TSF_Models;

namespace TSF
{
    class TSF_CategorieConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Cinema cine = value as Cinema;
            if (cine == null) return null;
            return $"Catégorie {cine.Categorie}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using TSF_Models;

namespace TSF
{
    class TSF_DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Cinema cine = value as Cinema;
            if (cine == null) return null;
            return $"{cine.Type} | Sortie le {cine.DateDeSortie.ToString("d MMMM yyyy")} | Noté {cine.Note}/20";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

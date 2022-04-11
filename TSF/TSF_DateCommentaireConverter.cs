using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using TSF_Models;
namespace TSF
{
    class TSF_DateCommentaireConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Commentaire com = value as Commentaire;
            if (com == null) return null;
            return $"{com.DatePublication.ToString("d/MM/yyyy")}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

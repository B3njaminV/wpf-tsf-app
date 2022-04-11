using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TSF
{
    /// <summary>
    /// Logique d'interaction pour UCCommentaire.xaml
    /// </summary>
    public partial class UCCommentaire : UserControl
    {
        public UCCommentaire()
        {
            InitializeComponent();
        }

        public string Texte
        {
            get
            {
                return (string)GetValue(TexteProperty);
            }
            set
            {
                SetValue(TexteProperty, value);
            }
        }

        public static readonly DependencyProperty TexteProperty = DependencyProperty.Register("Texte", typeof(string), typeof(UCCommentaire));

        public string Date
        {
            get
            {
                return (string)GetValue(DateProperty);
            }
            set
            {
                SetValue(DateProperty, value);
            }
        }

        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(UCCommentaire));

    }
}

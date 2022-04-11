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
    /// Logique d'interaction pour UCPersonnage.xaml
    /// </summary>
    public partial class UCPersonnage : UserControl
    {
        public UCPersonnage()
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

        public static readonly DependencyProperty TexteProperty = DependencyProperty.Register("Texte", typeof(string), typeof(UCPersonnage));

        public string Image
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(UCPersonnage));

    }
}

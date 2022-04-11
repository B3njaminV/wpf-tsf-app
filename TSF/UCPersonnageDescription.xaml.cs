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
    /// Logique d'interaction pour UCPersonnageDescription.xaml
    /// </summary>
    public partial class UCPersonnageDescription : UserControl
    {
        public UCPersonnageDescription()
        {
            InitializeComponent();
        }

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

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(UCPersonnageDescription));


        public string Pseudo
        {
            get
            {
                return (string)GetValue(PseudoProperty);
            }
            set
            {
                SetValue(PseudoProperty, value);
            }
        }

        public static readonly DependencyProperty PseudoProperty = DependencyProperty.Register("Pseudo", typeof(string), typeof(UCPersonnageDescription));

        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(UCPersonnageDescription));

    }
}

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
using TSF_Models;

namespace TSF
{
    /// <summary>
    /// Logique d'interaction pour UCListeCinema.xaml
    /// </summary>
    public partial class UCListeCinema : UserControl
    {

        public Bibliotheque bibliotheque => (App.Current as App).Manager;

        public UCListeCinema()
        {
            InitializeComponent();
            DataContext = bibliotheque;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bibliotheque.CinemaSelectionne = e.AddedItems[0] as Cinema;
            ListBoxCinema.Visibility = Visibility.Hidden;
        }
    }
}

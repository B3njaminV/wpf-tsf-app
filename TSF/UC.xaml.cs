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
    /// Logique d'interaction pour UC.xaml
    /// </summary>
    public partial class UC : UserControl
    {
        public Bibliotheque bibliotheque => (App.Current as App).Manager;

        public UC()
        {
            InitializeComponent();
            DataContext = bibliotheque.CinemaSelectionne;
            //ListBoxCinema.Visibility = Visibility.Visible;
            //DockPanelDescription.Visibility = Visibility.Hidden;
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count != 0 && bibliotheque.CinemaSelectionne != null)
            {
                bibliotheque.CinemaSelectionne.PersonnageSelectionne = e.AddedItems[0] as Personnage;
            }
        }

        private void Ajouter_Commentaire_Click(object sender, RoutedEventArgs e)
        {
            var ajout = new AjouterCommentaire();
            ajout.ShowDialog();
        }
    }
}

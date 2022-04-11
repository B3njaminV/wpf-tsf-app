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
using System.Windows.Shapes;
using TSF_Models;

namespace TSF
{
    /// <summary>
    /// Logique d'interaction pour AjouterCommentaire.xaml
    /// </summary>
    public partial class AjouterCommentaire : Window
    {
        public Bibliotheque bibliotheque => (App.Current as App).Manager;
        
        public AjouterCommentaire()
        {
            DataContext = bibliotheque.CinemaSelectionne;
            var c = new Commentaire("");
            LeCommentaire = new Commentaire(c.Texte);
            InitializeComponent();
        }

        public Commentaire LeCommentaire { get; set; }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
                bibliotheque.CinemaSelectionne.AjouterCommentaire(new Commentaire(LeCommentaire.Texte));
                Close();

        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

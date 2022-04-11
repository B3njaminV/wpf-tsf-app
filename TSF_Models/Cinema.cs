using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace TSF_Models
{
    [DataContract]
    public class Cinema : IEquatable<Cinema>, INotifyPropertyChanged
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="description">Description qui sera visible</param>
        /// <param name="note">Note moyenne donné</param>
        /// <param name="categorie">Categorie</param>
        public Cinema(string nom, string description, float note, Categorie categorie, string url, DateTime date, string type)
        {
            Nom = nom;
            Description = description;
            Note = note;
            Categorie = categorie;
            URL = url;
            DateDeSortie = date;
            Type = type;

            Personnages = new ReadOnlyCollection<Personnage>(liste);
            Commentaires = new ReadOnlyObservableCollection<Commentaire>(commentaires);

        }
        
        [DataMember]
        public ReadOnlyCollection<Personnage> Personnages { get; private set; }
        [DataMember]
        public ReadOnlyObservableCollection<Commentaire> Commentaires { get; private set; }

        /// <summary>
        /// Liste des personnages qui composent une série ou un film
        /// </summary>
        private List<Personnage> liste = new List<Personnage>();

        /// <summary>
        /// Listes des commentaires anonymes d'une série
        /// </summary>
        private ObservableCollection<Commentaire> commentaires = new ObservableCollection<Commentaire>();

        private Personnage personnageSelectionne;

        public Personnage PersonnageSelectionne
        {
            get => personnageSelectionne;
            set
            {
                if (personnageSelectionne != value)
                {
                    personnageSelectionne = value;
                    OnPropertyChanged(nameof(PersonnageSelectionne));//si le cinema sélectionné est différents, on invoque OnPropertyChanged pour apporter les modifications à la vue avec en paramètre la propriété qui change
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private string nom;
        [DataMember]
        public string Nom
        {
            get => nom;
            private set
            {
                nom = value.ToUpper();
            }
        }
        [DataMember]
        public float Note { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public string Type { get; private set; }
        [DataMember]
        public Categorie Categorie { get; private set; }
        [DataMember]
        public string URL { get; private set; }
        [DataMember]
        public DateTime DateDeSortie { get; private set; }

        /// <summary>
        /// On ajoute un Personnage en véfiant qu'il n'y ai pas de doublon
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        public bool AjouterPersonnage(Personnage p)
        {
            if (liste.Contains(p))
            {
                return false;
            }
            liste.Add(p);
            return true;

        }

        /// <summary>
        /// On ajoute un commentaire, aucune vérification , un commentaire peut être doublon
        /// </summary>
        /// <param name="c">Commentaire</param>
        public void AjouterCommentaire(Commentaire c)
        {
            commentaires.Add(c);
        }


        /// <summary>
        /// Cette méthode est la uniquement pour tester la liste de Personnage d'une Série
        /// </summary>
        public void AfficherListePersonnage()
        {
            foreach(Personnage p in liste)
            {
                Debug.WriteLine(p);
            }
        }

        public bool Equals(Cinema other)
        {
            return Nom == other.Nom;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Cinema);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}

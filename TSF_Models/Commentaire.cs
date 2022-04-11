using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace TSF_Models
{
    [DataContract]
    public class Commentaire : INotifyPropertyChanged
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="texte">Texte</param>
        public Commentaire(string texte)
        {
            Texte = texte;
            DatePublication = DateTime.Today;
        }

        [DataMember]
        private string texte;
        public string Texte 
        {
            get => texte;
            set
            {
                texte = value;
                OnPropertyChanged(nameof(Texte));

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

        public DateTime DatePublication { get; private set; }

    }
}

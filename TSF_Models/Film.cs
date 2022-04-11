using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TSF_Models
{
    [DataContract]
    public class Film : Cinema
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="description">Description</param>
        /// <param name="note">Note moyenne calculé</param>
        /// <param name="temps">Temps du film (en minutes)</param>
        /// <param name="categorie">Categorie</param>
        public Film(string nom, string description, float note, int temps, Categorie categorie, string url, DateTime date) :base(nom, description, note, categorie, url, date, "Film")
        {
            Temps = temps;
            
        }

        [DataMember]
        public int Temps { get; private set; }

        public override string ToString() => $"{Nom}";

    }
}

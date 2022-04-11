using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TSF_Models
{
    [DataContract]
    public class Serie : Cinema
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="nom">Nom</param>
        /// <param name="description">Description</param>
        /// <param name="note">Note moyenne</param>
        /// <param name="nbep">Nombre d'épisodes de la série</param>
        /// <param name="nbsa">Nombre de saisons</param>
        /// <param name="categorie">Categorie (trié selon ce paramètre)</param>
        public Serie(string nom, string description, float note, int nbep, int nbsa, Categorie categorie, string url, DateTime date) : base(nom, description, note, categorie, url, date, "Serie")
        {
            Nbep = nbep;
            Nbsa = nbsa;
        }
        [DataMember]
        public int Nbep { get; private set; }
        [DataMember]
        public int Nbsa { get; private set; }

        public override string ToString() => $"{Nom}";
    }
}

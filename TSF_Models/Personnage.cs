using System;
using System.Runtime.Serialization;
using System.Text;

namespace TSF_Models
{
    [DataContract]
    public class Personnage
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="nom">Nom'(visible depuis le menu compte)</param>
        /// <param name="pseudo">Pseudo (visible depuis l'app)</param>
        /// <param name="description">Description</param>
        public Personnage(string nom, string pseudo, string url, string description)
        {
            Nom = nom;
            Pseudo = pseudo;
            Description = description;
            URL = url;
        }

        public Personnage(string nom, string pseudo, string url) : this(nom, pseudo, url, "Pas de description")
        {
        }
        [DataMember]
        public string Nom { get; private set; }
        [DataMember]
        public string Pseudo { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public string URL { get; private set; }

        public override string ToString() => $"{Nom}, alias {Pseudo}, {Description}";

        public bool Equals(Personnage other)
        {
            return Nom == other.Nom;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj as Personnage);
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }
    }
}

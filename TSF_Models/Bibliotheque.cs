using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace TSF_Models
{
    [DataContract]
    public class Bibliotheque : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persistance">dépendance à injecter</param>
        public Bibliotheque(/*IPersistance persistance*/) {
            Cinema = new ReadOnlyCollection<Cinema>(cinema);
            //Persistance = persistance;
        }

        public ReadOnlyCollection<Cinema> Cinema { get; private set; }

        [DataMember]
        public List<Cinema> cinema = new List<Cinema>();

        private Cinema cinemaSelectionne;

        /// <summary>
        /// Il s'agit du Cinema qu'on sélectionne dans la vue
        /// </summary>
        public Cinema CinemaSelectionne 
        {
            get => cinemaSelectionne;
            set
            {
                if (cinemaSelectionne != value)
                {
                    cinemaSelectionne = value;
                    OnPropertyChanged(nameof(CinemaSelectionne));//si le cinema sélectionné est différents, on invoque OnPropertyChanged pour apporter les modifications à la vue avec en paramètre la propriété qui change
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// On ajoute le Cinema c en vérifiant qu'il n'est pas déjà dans la liste
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public bool AjouterCinema(Cinema c)
        {
            if (cinema.Contains(c))
            {
                return false;
            }
            cinema.Add(c);
            return true;
        }

        /// <summary>
        /// On supprime le Cinema c en vérifiant que celui ci est déjà dans la liste
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public bool SupprimerCinema(Cinema c)
        {
            if (!cinema.Contains(c))
            {
                return false;
            }
            cinema.Remove(c);
            return true;
        }

        /// <summary>
        /// LINQ Cette méthode retourne une liste de Cinema qui possède la Categorie passé en paramètre
        /// </summary>
        /// <param name="categ">Categorie du parametre</param>
        /// <returns>List<Cinema></returns>
        public List<Cinema> CinemaTrouveAvecCategorie(Categorie categ)
        {
            return cinema.Where(Cinema => Cinema.Categorie == categ).ToList();
        }
        /// <summary>
        /// dépendance vers le gestionnaire de la persistance
        /// </summary>
        public IPersistance Persistance { get; set; }

        public void ChargeCinema()
        {
            cinema.Clear();
            CinemaSelectionne = null;
            var donnee = Persistance?.ChargeCinema();
            if (donnee == null) return;
            foreach(Cinema c in donnee)
            {
                cinema.Add(c);
            }

            CinemaSelectionne = Cinema[0];
        }

        public void EnregistreCinema()
        {
            Persistance?.EnregistreCinema(cinema);
        }

        public void Chargement()
        {
            Serie s1 = new Serie("Casa De Papel", "Un homme mystérieux, surnommé le Professeur, planifie le meilleur braquage jamais réalisé. Pour exécuter son plan, il recrute huit des meilleurs malfaiteurs en Espagne qui n'ont rien à perdre. Le but est d'infiltrer la Fabrique nationale de la monnaie et du timbre afin d'imprimer 2,4 milliards d'euros, en petites coupures de 50 € et cela en moins de onze jours, sans victimes — malgré la présence de 67 otages, dont la fille de l'ambassadeur du Royaume", 15, 38, 5, Categorie.POLICIER, "img/cdp.jpg", new DateTime(2017, 05, 02));           
            s1.AjouterPersonnage(new Personnage("Ursula Corbero", "Tokyo", "img/tokyo.png", "Le personnage au coeur de l'intrigue"));
            s1.AjouterPersonnage(new Personnage("Alvaro Morte", "El Profesor", "img/profesor.png", "Le cerveau du braquage"));
            s1.AjouterPersonnage(new Personnage("Alba Flores", "Nairobi", "img/nairobi.png", "Sa spécialité ? Les faux billets !"));
            s1.AjouterPersonnage(new Personnage("Miguel Herran", "Rio", "img/rio2.png", "Le Mozart des ordinateurs"));
            s1.AjouterPersonnage(new Personnage("Jaime Lorente", "Denver", "img/denver.png", "Braqueur de père en fils !"));
            s1.AjouterPersonnage(new Personnage("Itziar Ituno", "Lisbonne", "img/lisbonne.png", "Une enquêtrice dont le quotidien va se bouleverser"));
            s1.AjouterPersonnage(new Personnage("Darko Perik", "Helsinki", "img/helsinki.png", "Un véritable combattant !"));
            s1.AjouterPersonnage(new Personnage("Esther Acebo", "Monica", "img/monica.png", "Son destin va se bouleverser !"));
            s1.AjouterCommentaire(new Commentaire("Une série pleine de rebondissement !"));
            AjouterCinema(s1);

            Serie s2 = new Serie("Lupin", "Il y a 25 ans, la vie du jeune Assane Diop est bouleversée lorsque son père meurt après avoir été accusé d'un crime qu'il n'a pas commis. Aujourd’hui, Assane va s'inspirer de son héros, Arsène Lupin - Gentleman Cambrioleur, pour le venger…", 16, 8, 1, Categorie.POLICIER, "img/lupin.png", new DateTime(2021, 01, 08));
            s2.AjouterPersonnage(new Personnage("Omar Sy", "Assane Diop", "img/arsene.jpg", "Ce personnage s'inspire du véritable personnage d'Arsène LUPIN"));
            s2.AjouterCommentaire(new Commentaire("TOP !"));
            AjouterCinema(s2);

            Film f1 = new Film("Le Pont des Espions", "En pleine guerre froide, la CIA confie à James Donovan, avocat spécialiste des assurances, la défense d'un espion soviétique. Contre toute attente, l'homme de loi n'est pas de paille et refuse, quoiqu'il lui en coûte, de sacrifier les droits de son client, promis au peloton, sur l'autel d'un patriotisme dévoyé. Son art de la négociation va lui permettre de bâtir un pont entre l'Est et l'Ouest.", 18, 142, Categorie.ESPIONNAGE, "img/pde.jpg", new DateTime(2015, 08, 16));
            f1.AjouterPersonnage(new Personnage("Tom Hanks", "James Donovan", "img/th.jpeg", "Le personnage principa du film"));
            f1.AjouterCommentaire(new Commentaire("Très bien"));
            f1.AjouterCommentaire(new Commentaire("Excellent film avec Tom Hanks"));
            f1.AjouterCommentaire(new Commentaire("Très bon film"));
            AjouterCinema(f1);

            Film f2 = new Film("30 jours max", "Rayane est un jeune flic trouillard et maladroit sans cesse moqué par les autres policiers. Le jour où son médecin lui apprend à tort qu'il n'a plus que trente jours à vivre, Il comprend que c'est sa dernière chance pour devenir un héros au sein de son commissariat et impressionner sa collègue Stéphanie. L'éternel craintif se transforme alors en véritable tête brûlée qui prendra tous les risques pour coincer un gros caïd.", 12, 90, Categorie.ACTION, "img/30.png", new DateTime(2020, 07, 21)); 
            f2.AjouterPersonnage(new Personnage("Tarek Boudali", "Rayane", "img/tarek.jpg", "Rayanne va-t-il arriver à ses fins ?"));
            f2.AjouterPersonnage(new Personnage("Philippe Lacheau", "tony", "img/lacheau.jpg", "Tony toujours la pour Rayane, ou pas !"));
            f2.AjouterCommentaire(new Commentaire("Un film francais à voir"));
            AjouterCinema(f2);

            Film f3 = new Film("La Mission", "Cinq ans après la fin de la Guerre de Sécession, le capitaine Jefferson Kyle Kidd, vétéran de trois guerres, sillonne le pays de ville en ville en qualité de rapporteur publique et tient les gens informés, grâce à ses lectures, des péripéties des grands de ce monde, des querelles du gratin, ainsi que des plus terribles catastrophes ou aventures du bout du monde. En traversant les plaines du Texas, il croise le chemin de Johanna, une enfant de 10 ans capturée 6 ans plus tôt par la tribu des Kiowa et élevée comme l’une des leurs. Rescapée et renvoyée contre son gré chez sa tante et son oncle par les autorités, Johanna est hostile à ce monde qu’elle va devoir rejoindre et ne connait pas. Kidd accepte de la ramener à ce domicile auquel la loi l’a assignée. Pendant des centaines de kilomètres, alors qu’ils traversent une nature hostile, ils vont devoir affronter les nombreux écueils, aussi bien humains que sauvages, qui jalonnent la route vers ce que chacun d’entre eux pourra enfin appeler son foyer.", 17, 120, Categorie.AVENTURE, "img/mission.jpg", new DateTime(2021, 02, 10));
            f3.AjouterPersonnage(new Personnage("Tom Hanks", "Capitaine Jefferson", "img/th.jpeg", "Un personnage émouvant !"));
            f3.AjouterCommentaire(new Commentaire("Excellent film avec Tom Hanks"));
            f3.AjouterCommentaire(new Commentaire("Un très bon film"));
            AjouterCinema(f3);

            Serie s3 = new Serie("bureau des legendes", "Bienvenue dans le quotidien du service le plus secret des services secrets français : le Bureau des Légendes, qui pilote à distance des agents clandestins partis sur le terrain. Malotru, un agent de retour après 6 ans de mission en Syrie, peine à abandonner sa légende alors que Nadia, son amour de Damas, arrive à Paris. Au risque de mettre en danger tout son service.", 14, 100, 5, Categorie.ESPIONNAGE, "img/bdl.jpg", new DateTime(2021, 01, 08));
            s3.AjouterPersonnage(new Personnage("Mathieu Kassovitz", "Malotru", "img/malotru.png", "Personnage central de la série, mais est-il si fidèle ?"));
            s3.AjouterPersonnage(new Personnage("Jean Pierre Daroussin", "Henri Duflot", "img/henri.png", "Directeur du Bureau des Legendes de la DGSE"));
            s3.AjouterPersonnage(new Personnage("Sara Giraudeau", "Marina Loiseau", "img/marina.png", "Une nouvelle recrue avec un fort potentiel !"));
            s3.AjouterCommentaire(new Commentaire("Une série au coeur de la DGSE !"));
            AjouterCinema(s3);

            Serie s4 = new Serie("Blacklist", "La série, qui se déroule principalement à Washington, raconte l'histoire d'un ancien officier de l'US Navy, Raymond « Red » Reddington, qui a disparu vingt ans plus tôt pour devenir l'un des dix fugitifs les plus recherchés du FBI et un criminel de premier plan, surnommé le Médiateur du crime.", 18, 180, 9, Categorie.POLICIER, "img/blacklist.jpeg", new DateTime(2023, 12, 09));
            AjouterCinema(s4);
            Serie s5 = new Serie("Mentalist", "...", 20, 151, 7, Categorie.POLICIER, "img/mentalist.jpg", new DateTime(2008, 09, 23));
            AjouterCinema(s5);
            Film f4 = new Film("Free Guy", "...", 15, 120, Categorie.ACTION, "img/freeguy.jpg", new DateTime(2021,01,01));
            AjouterCinema(f4);
            Film f5 = new Film("OSS117", "...", 12, 80, Categorie.ACTION, "img/oss117.jpg", new DateTime(2021, 01, 01));
            AjouterCinema(f5);
            Serie s6 = new Serie("Person of Interest", "...", 20, 103, 5, Categorie.AVENTURE, "img/pof.jpg", new DateTime(2011,09,22));
            AjouterCinema(s6);
            Serie s7 = new Serie("Elementary", "...", 20, 154, 7, Categorie.POLICIER, "img/elementary.jpg", new DateTime(2012,09,27));
            AjouterCinema(s7);
            Film f6 = new Film("Jumanji", "...", 14, 120, Categorie.ACTION, "img/jumanji.jpg", new DateTime(2017,01,01));
            AjouterCinema(f6);
            Serie s8 = new Serie("Prison Break", "...", 12, 90, 5, Categorie.ACTION, "img/pb.jpg", new DateTime(2005,08,29));
            AjouterCinema(s8);
            Film f7 = new Film("Kaamelott", "...", 15, 120, Categorie.ACTION, "img/kam.jpg", new DateTime(2021, 07, 21));
            AjouterCinema(f7);
            Film f8 = new Film("No Time to Die", "...", 18, 163, Categorie.ESPIONNAGE, "img/nttd.jpg", new DateTime(2021,01,01));
            AjouterCinema(f8);
            CinemaSelectionne = Cinema[0];

        }

    }
}


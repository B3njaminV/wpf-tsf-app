using System;
using System.Collections.Generic;
using TSF_Models;
using System.Diagnostics;

namespace TSF_Stub
{
    public class Stub : IPersistance
    {
        public IEnumerable<Cinema> ChargeCinema()
        {


            List<Cinema> cine = new List<Cinema>()
            {
                new Serie("Casa De Papel", "Un homme mystérieux, surnommé le Professeur, planifie le meilleur braquage jamais réalisé. Pour exécuter son plan, il recrute huit des meilleurs malfaiteurs en Espagne qui n'ont rien à perdre. Le but est d'infiltrer la Fabrique nationale de la monnaie et du timbre afin d'imprimer 2,4 milliards d'euros, en petites coupures de 50 € et cela en moins de onze jours, sans victimes — malgré la présence de 67 otages, dont la fille de l'ambassadeur du Royaume", 15, 38, 5, Categorie.POLICIER, "img/cdp.jpg", new DateTime(2017, 05, 02)),
                new Film("Le Pont des Espions", "En pleine guerre froide, la CIA confie à James Donovan, avocat spécialiste des assurances, la défense d'un espion soviétique. Contre toute attente, l'homme de loi n'est pas de paille et refuse, quoiqu'il lui en coûte, de sacrifier les droits de son client, promis au peloton, sur l'autel d'un patriotisme dévoyé. Son art de la négociation va lui permettre de bâtir un pont entre l'Est et l'Ouest.", 18, 142, Categorie.ESPIONNAGE, "img/pde.jpg", new DateTime(2015, 08, 16)),

            };
            /*
            cine[0].AjouterPersonnage(new Personnage("Ursula", "Tokyo", "img/tokyo.png", "Un personnage plein de rebondissement"));
            cine[0].AjouterPersonnage(new Personnage("Alvaro Morte", "El Profesor", "img/profesor.png", "Le cerveau du braquage"));
            cine[1].AjouterPersonnage(new Personnage("Tom Hanks", "James Donovan", "img/th.jpeg", "Le personnage principa du film"));
            /*
            cine[1].AjouterCommentaire(new Commentaire("Très bien", DateTime.Today));
            cine[1].AjouterCommentaire(new Commentaire("Excellent film avec Tom Hanks", DateTime.Today));
            cine[1].AjouterCommentaire(new Commentaire("Très bon film", DateTime.Today));
            */
            return cine;
        }

        public void EnregistreCinema(IEnumerable<Cinema> cinema)
        {
            Debug.WriteLine("Sauvegarde effectué !");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MODULE5_TP1.Models
{
    public class Data
    {
        private static Data _instance;
        static readonly object instanceLock = new object();

        private Data()
        {
            GetMeuteDeChats();
        }

        public static Data Instance
        {
            get
            {
                if (_instance == null) //Les locks prennent du temps, il est préférable de vérifier d'abord la nullité de l'instance.
                {
                    lock (instanceLock)
                    {
                        if (_instance == null) //on vérifie encore, au cas où l'instance aurait été créée entretemps.
                            _instance = new Data();
                    }
                }
                return _instance;
            }
        }

        private List<Chat> listeChats = new List<Chat>();

        public List<Chat> ListeChats
        {
            get { return listeChats; }
            set { listeChats = value; }
        }

        private void GetMeuteDeChats()
        {
            var i = 1;
            listeChats.Add(new Chat { Id = i++, Nom = "Felix", Age = 3, Couleur = "Roux" });
            listeChats.Add(new Chat { Id = i++, Nom = "Minette", Age = 1, Couleur = "Noire" });
            listeChats.Add(new Chat { Id = i++, Nom = "Miss", Age = 10, Couleur = "Blanche" });
            listeChats.Add(new Chat { Id = i++, Nom = "Garfield", Age = 6, Couleur = "Gris" });
            listeChats.Add(new Chat { Id = i++, Nom = "Chatran", Age = 4, Couleur = "Fauve" });
            listeChats.Add(new Chat { Id = i++, Nom = "Minou", Age = 2, Couleur = "Blanc" });
            listeChats.Add(new Chat { Id = i, Nom = "Bichette", Age = 12, Couleur = "Rousse" });
        }
    }
}
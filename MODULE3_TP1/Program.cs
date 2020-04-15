using MODULE3_TP1.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODULE3_TP1
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            InitialiserDatas();


            Console.WriteLine("______________________________________\n");
            Console.WriteLine("Pénoms des auteurs dont le nom commence par un G :\n");
            var auteursNomCommencantParG = ListeAuteurs.Where(a => a.Nom.Substring(0, 1) == "G");
            foreach (var auteur in auteursNomCommencantParG)
            {
                Console.WriteLine($"{auteur.Prenom}");
            }


            Console.WriteLine("______________________________________\n");
            Console.WriteLine("Auteur ayant écrit le plus de livres :\n");
            Auteur auteurProlifique = ListeAuteurs[0];
            int maxLivres = 0;
            foreach (var auteur in ListeAuteurs)
            {
                var nbLivres = ListeLivres.Where(l => l.Auteur == auteur).Count();
                if (nbLivres > maxLivres)
                {
                    auteurProlifique = auteur;
                    maxLivres = nbLivres;
                }
            }
            Console.WriteLine($"{auteurProlifique.Prenom} {auteurProlifique.Nom}");


            Console.WriteLine("______________________________________\n");
            Console.WriteLine("Nombre moyen de pages par livre et par auteur :\n");
            foreach (var auteur in ListeAuteurs)
            {
                var livresAuteur = ListeLivres.Where(l => l.Auteur == auteur);
                var nbLivres = livresAuteur.Count();
                var pagesLivres = ListeLivres.Where(l => l.Auteur == auteur).Select(l => l.NbPages);
                int totalPages = 0;

                foreach (var pagesLivre in pagesLivres)
                {
                    totalPages += pagesLivre;
                }
                Console.WriteLine($"{auteur.Prenom} {auteur.Nom} : ");
                if (nbLivres > 0) {
                    Console.WriteLine(totalPages / nbLivres);
                } else
                {
                    Console.WriteLine("N'a écrit aucun livre de cette liste");
                }  
            }


            Console.WriteLine("______________________________________\n");
            Console.WriteLine("Titre du livre avec le plus de pages :\n");
            Livre plusGrosLivre = ListeLivres[0];
            int maxPages = 0;
            foreach (var livre in ListeLivres)
            {
                var nbPages = livre.NbPages;
                if (nbPages > maxPages)
                {
                    plusGrosLivre = livre;
                    maxPages = nbPages;
                }
            }
            Console.WriteLine($"{plusGrosLivre.Titre}");


            Console.WriteLine("______________________________________\n");
            var moyenne = ListeAuteurs.SelectMany(a => a.Factures).Select(f=>f.Montant).Average();
            Console.WriteLine($"En moyenne, les auteurs ont gagné : {moyenne} euros");


            Console.WriteLine("______________________________________\n");
            Console.WriteLine("Liste des livres par auteur :\n");
            foreach (var auteur in ListeAuteurs)     
            {
                Console.WriteLine($"Auteur : {auteur.Prenom} {auteur.Nom}");
                Console.WriteLine("Livres : ");
                var titres = ListeLivres.Where(l => l.Auteur == auteur).Select(l => l.Titre);
                foreach (var titre in titres)
                {
                    Console.WriteLine($"{titre}");
                }
            }

            Console.ReadKey();
        }
    }
}

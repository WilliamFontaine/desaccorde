using Modele;
using System;
using System.Collections.Generic;

namespace Test_Manager
{
    class Program
    {
        static void DisplayUser(IEnumerable<Utilisateur> l)
        {
            foreach (Utilisateur u in l)
            {
                Console.WriteLine(u);
            }
        }

        static void DisplayOeuvre(IEnumerable<Oeuvre> oeu)
        {
            foreach (Oeuvre o in oeu)
            {
                Console.WriteLine(o);
            }
        }

#pragma warning disable IDE0060 // Supprimer le paramètre inutilisé
        static void Main(string[] args)
#pragma warning restore IDE0060 // Supprimer le paramètre inutilisé
        {
            Manager m = new(new Stub.Stub());

            Console.WriteLine("Test de Manager.Artiste :");
            Console.WriteLine();

            m.SupprimerArtiste(new Artiste("artiste", "desc", new DateTime(1999, 06, 06), "/img"));
            m.AjouterArtiste("artiste1-musique", "desc1", new DateTime(1999, 06, 06), "/img");
            m.AjouterArtiste("artiste2-refrain", "desc2", new DateTime(1999, 06, 06), "/img");

            foreach (Artiste a in m.Artistes)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Morceau :");
            Console.WriteLine();

            m.AjouterMorceau("Morceau1-couplet", m.Artistes[0], "3:12", "/img", new DateTime(2010, 01, 16), Genre.Electro, "");
            m.AjouterMorceau("Morceau2-refrain", m.Artistes[0], "3:12", "/img", new DateTime(2011, 12, 09), Genre.Folk, "");
            m.AjouterMorceau("Morceau3-musique", m.Artistes[1], "3:12", "/img", new DateTime(1999, 10, 10), Genre.Pop, "");
            m.AjouterMorceau("Morceau4-couplet", m.Artistes[0], "3:12", "/img", new DateTime(2021, 06, 30), Genre.Rap, "");
            m.AjouterMorceau("Morceau5-refrain couplet", m.Artistes[1], "3:12", "/img", new DateTime(2011, 03, 15), Genre.RnB, "");
            Console.WriteLine("Affichage des morceaux: ");
            foreach (Oeuvre o in m.Oeuvres)
            {
                if (o is Morceau)
                {
                    Console.WriteLine(o);
                }
            }
            Console.WriteLine(" ------------ ");
            Console.WriteLine("Affichage des oeuvres: ");
            DisplayOeuvre(m.Oeuvres);

            m.SupprimerMorceau(new Morceau("Morceau5 ", m.Artistes[1], "3:12", new DateTime(2000, 10, 10), "/img", Genre.RnB, ""));
            Console.WriteLine(" ------------ ");
            Console.WriteLine("suppression d'un morceau: ");
            foreach (Oeuvre o in m.Oeuvres)
            {
                if (o is Morceau)
                {
                    Console.WriteLine(o);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Album :");
            Console.WriteLine();

            Console.WriteLine("Test d'ajout de 2 albums");
            m.AjouterAlbum("test1", "desc album 1", m.Artistes[0], "/img", new DateTime(2021, 05, 11));
            m.AjouterAlbum("test2-refrain", "desc album 2", m.Artistes[0], "/img", new DateTime(2021, 05, 11));
            foreach (Oeuvre o in m.Oeuvres)
            {
                if (o is Album)
                {
                    Console.WriteLine(o);
                }
            }
            Console.WriteLine(" ------------ ");
            Console.WriteLine("Test de suppression d'un album :");
            m.Supprimeralbum(new Album("test1", "desc album 1", m.Artistes[0], "/img", new DateTime(2021, 05, 11)));
            foreach (Oeuvre o in m.Oeuvres)
            {
                if (o is Album)
                {
                    Console.WriteLine(o);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Utilisateur :");
            Console.WriteLine();

            m.AjouterUtilisateur("Jean", "Dupont", "jp", new DateTime(2002, 06, 06), "admin@admin.fr", "passe", "/img");
            Console.Write("Display utilisateur : ");
            DisplayUser(m.Utilisateurs);
            m.SeConnecter("admin@admin.fr", "passe");
            Console.Write("IsConnecte ? ");
            Console.WriteLine(m.IsConnecte());
            Console.Write("Display CurrentUser : ");
            Console.WriteLine(m.CurrentUser);
            Console.WriteLine();
            Console.WriteLine("Test de Manager.Playlist :");
            Console.WriteLine();

            m.AjouterPlaylist("playlist 1", "desc playlist 1", "");
            m.Playlists[0].AjouterListOeuvres(new List<Oeuvre>(){
                new Morceau("Morceau1 ", m.Artistes[0], "3:12", new DateTime(2000, 12, 30), "/img", Genre.Electro,""),
                new Morceau("Morceau2 ", m.Artistes[0], "3:12", new DateTime(2005, 10, 12), "/img", Genre.Folk,""),
                new Morceau("Morceau3 ", m.Artistes[1], "3:12", new DateTime(2000, 12, 21), "/img", Genre.Pop,""),
                new Morceau("Morceau4 ", m.Artistes[0], "3:12", new DateTime(2009, 09, 10), "/img", Genre.Rap,""),
                new Morceau("Morceau5 ", m.Artistes[1], "3:12", new DateTime(2017, 10, 13), "/img", Genre.RnB,""),
                new Album("test1", "desc album 1", m.Artistes[0], "/img", new DateTime(2021, 05, 11)),
                new Album("test2", "desc album 2", m.Artistes[0], "/img", new DateTime(2021, 07, 15))
            });
            m.Utilisateurs[0].AjouterOeuvre(m.Oeuvres[0]);
            m.AjouterUtilisateur("marie", "Dupont", "mp", new DateTime(2002, 06, 06), "admin@admin.fr", "passe", "/img");
            Console.WriteLine("Test du bon fonctionnement des favoris: ");
            foreach (Oeuvre o in m.Utilisateurs[0].Albums)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(" ------------ ");
            foreach (Oeuvre o in m.Playlists[0].Morceaux)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Avis :");
            Console.WriteLine();

            m.AjouterArtiste("artiste", "desc", new DateTime(1999, 06, 06), "/img");
            m.AjouterMorceau("Morceau0 ", m.Artistes[0], "3:12", "/img", new DateTime(2000, 10, 10), Genre.Electro, "");
            Console.WriteLine("Utilisateur Like le MorceauO :");
            m.Noter(m.Oeuvres[0], Modele.Type.Like);
            Console.Write("Nb Likes: ");
            Console.WriteLine(m.GetNbLikes(m.Oeuvres[0]));

            Console.WriteLine(" ------------ ");

            m.Noter(m.Oeuvres[0], Modele.Type.Indesirable);
            Console.WriteLine("Utilisateur DisLike le MorceauO :");
            Console.Write("Nb Likes: ");
            Console.WriteLine(m.GetNbLikes(m.Oeuvres[0]));

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Tri :");
            Console.WriteLine();
            List<Morceau> morceaux = new();
            foreach (Oeuvre o in m.Morceaux)
            {
                morceaux.Add(o as Morceau);
            }

            Console.WriteLine(" - Tri Dates - ");
            foreach (Oeuvre o in m.TriDateAsc(morceaux))
            {
                Console.WriteLine($"{o}, {o.Parution}");
            }
            Console.WriteLine();

            Console.WriteLine(" - Tri Artiste - ");
            DisplayOeuvre(m.TriArtisteAsc(morceaux));
            Console.WriteLine();

            Console.WriteLine(" - Tri Alphabetique - ");
            DisplayOeuvre(m.TriTitreAsc(morceaux));
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Test de Manager.Recherche :");
            Console.WriteLine();

            Console.WriteLine(" - Resultat Albums, mot: refrain -");
            DisplayOeuvre(m.RechercheAlbum("refrain"));

            Console.WriteLine(" - Resultat Artistes, mot: refrain -");
            foreach (Artiste a in m.RechercheArtiste("refrain"))
            {
                Console.WriteLine(a);
            }

            Console.WriteLine(" - Resultat Morceaux, mot: refrain -");
            DisplayOeuvre(m.RechercheMorceau("refrain"));

            Console.WriteLine(" - Resultat Morceaux, mot: couplet -");
            DisplayOeuvre(m.RechercheMorceau("couplet"));

        }
    }
}

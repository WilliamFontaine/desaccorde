using Modele;
using System;
using System.Collections.Generic;

namespace Test_Recherche
{
    class Program
    {
#pragma warning disable IDE0060 // Supprimer le paramètre inutilisé
        static void Main(string[] args)
#pragma warning restore IDE0060 // Supprimer le paramètre inutilisé
        {
            Console.WriteLine("test de la fonction de recherche");

            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Artiste a2 = new("Artiste 2", "desc 1", new DateTime(2003, 12, 16), "/img");
            Artiste a3 = new("Artiste 3", "desc 1", new DateTime(1998, 03, 16), "/img");
            Artiste a4 = new("Artiste 4", "desc 1", new DateTime(1987, 03, 16), "/img");

            IEnumerable<Artiste> artistes = new List<Artiste>() { a1, a2, a3, a4 };


            Morceau o1 = new("A_Morceau1", a1, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Rap, "");
            Morceau o2 = new("M_Morceau2", a2, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Classique, "");
            Morceau o3 = new("A_Morceau3", a2, "1:40", new DateTime(2021, 4, 29), "/img", Genre.Rap, "");
            Morceau o4 = new("B_Morceau4", a3, "3:04", new DateTime(2006, 10, 01), "/img", Genre.Rock, "");
            Morceau o5 = new("A_Fake5", a3, "2:24", new DateTime(2006, 04, 30), "/img", Genre.RnB, "");
            Morceau o6 = new("D_Morceau6", a1, "3:04", new DateTime(2007, 01, 01), "/img", Genre.Afro, "");
            Morceau o7 = new("C_Morceau7", a2, "1:40", new DateTime(2010, 10, 11), "/img", Genre.Folk, "");
            Morceau o8 = new("C_Fake8", a2, "3:54", new DateTime(2020, 06, 07), "/img", Genre.Country, "");
            Morceau o9 = new("E_Morceau9", a1, "3:04", new DateTime(2021, 11, 01), "/img", Genre.Punk, "");
            Morceau o10 = new("J_Morceau10", a2, "1:40", new DateTime(2018, 01, 04), "/img", Genre.Metal, "");
            Morceau o11 = new("S_Morceau11", a4, "2:04", new DateTime(2021, 11, 01), "/img", Genre.Blues, "");
            Morceau o12 = new("D_Morceau12", a1, "3:34", new DateTime(2020, 10, 21), "/img", Genre.Jazz, "");
            Morceau o13 = new("F_Fake13", a2, "1:40", new DateTime(2001, 01, 01), "/img", Genre.Kpop, "");

            IEnumerable<Morceau> tracklist = new List<Morceau>() { o1, o2, o3, o4, o5, o6, o7, o8, o9, o10, o11, o12, o13 };

            IEnumerable<Oeuvre> listMorceau1 = new List<Oeuvre>() { o1, o6, o9, o12 };
            IEnumerable<Oeuvre> listMorceau2 = new List<Oeuvre>() { o2, o3, o7, o8, o10, o13 };
            IEnumerable<Oeuvre> listMorceau3 = new List<Oeuvre>() { o4, o5 };
            IEnumerable<Oeuvre> listMorceau4 = new List<Oeuvre>() { o11 };

            Album al1 = new("Album 1", "description 1", a1, "/img", new DateTime(2020, 10, 20), listMorceau1);
            Album al2 = new("Album 2", "description 2", a2, "/img", new DateTime(2020, 10, 20), listMorceau2);
            Album al3 = new("Album 3", "description 3", a3, "/img", new DateTime(2020, 10, 20), listMorceau3);
            Album al4 = new("Album 4", "description 4", a4, "/img", new DateTime(2020, 10, 20), listMorceau4);


            IEnumerable<Album> albums = new List<Album>() { al1, al2, al3, al4 };

            Console.WriteLine("Recherche par morceau");
            Console.WriteLine();

            var recherche1 = new RechercheMorceau();
            Console.WriteLine("Recherche de: A");
            var list1 = recherche1.Rechercher(tracklist, "A");

            foreach (Morceau m in list1)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();
            Console.WriteLine("Recherche de: Morceau");

            var list2 = recherche1.Rechercher(tracklist, "Morceau");

            foreach (Morceau m in list2)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Recherche par genre");
            Console.WriteLine();

            var recherche2 = new RechercheGenre();
            Console.WriteLine("Recherche de: Jazz");
            var list3 = recherche2.Rechercher(tracklist, "Jazz");

            foreach (Morceau m in list3)
            {
                Console.Write(m);
                Console.WriteLine(m.Genre);
            }

            Console.WriteLine();
            Console.WriteLine("Recherche de: Kpop");
            var list4 = recherche2.Rechercher(tracklist, "Kpop");

            foreach (Morceau m in list4)
            {
                Console.Write(m);
                Console.WriteLine(m.Genre);
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Recherche par artiste");
            Console.WriteLine();

            var recherche3 = new RechercheArtiste();

            Console.WriteLine("Recherche de: Artiste 1");
            var list5 = recherche3.Rechercher(artistes, "Artiste 1");

            foreach (Artiste a in list5)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Recherche par album");
            Console.WriteLine();

            var rechercher4 = new RechercheAlbum();

            Console.WriteLine("Recherche de: Album 3");
            var list6 = rechercher4.Rechercher(albums, "Album 3");

            foreach (Album a in list6)
            {
                Console.WriteLine(a);
            }

        }
    }
}

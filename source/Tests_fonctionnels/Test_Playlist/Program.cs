using Modele;
using System;
using System.Collections.Generic;

namespace Test_Playlist
{
    class Program
    {
        static void Display(Playlist p)
        {
            foreach (Oeuvre o in p.Morceaux)
            {
                if (o is Album)
                {
                    Console.WriteLine(o);
                    Console.WriteLine("Titres :");
                    foreach (Morceau m in (o as Album).Tracklist)
                    {
                        Console.WriteLine(m);
                    }
                }
                else
                {
                    Console.WriteLine(o);
                }
            }
        }

#pragma warning disable IDE0060 // Supprimer le paramètre inutilisé
        static void Main(string[] args)
#pragma warning restore IDE0060 // Supprimer le paramètre inutilisé
        {
            Console.WriteLine("Test des playlists");

            Artiste ar1 = new("Artiste 1", "desc artiste 1", new DateTime(2001, 03, 16), "/img");
            Artiste ar2 = new("Artiste 2", "desc artiste 2", new DateTime(1969, 10, 17), "/img");

            Oeuvre al1 = new Album("test1", "desc album 1", ar1, "/img", new DateTime(2021, 05, 11));
            Oeuvre al2 = new Album("test2", "desc album 2", ar2, "/img", new DateTime(2019, 02, 13));

            Morceau m1 = new("morceau 1", ar1, "3:21", new DateTime(2021, 05, 11), "/img", Genre.Rap, "");
            Morceau m2 = new("morceau 2", ar2, "4:03", new DateTime(2019, 02, 13), "/img", Genre.Rock, "");
            Morceau m3 = new("morceau 3", ar1, "2:51", new DateTime(2021, 05, 11), "/img", Genre.Rap, "");
            Morceau m4 = new("morceau 3", ar2, "3:01", new DateTime(2019, 02, 13), "/img", Genre.Rock, "");

            IEnumerable<Morceau> list = new List<Morceau>() { m2, m4 };

            Album album = al2 as Album;
            album.AjouterListOeuvre(list);

            Playlist p = new("Ma Playlist", "desc", "");
            p.AjouterOeuvre(m1);
            p.AjouterOeuvre(m3);
            p.AjouterOeuvre(al1);
            p.AjouterOeuvre(al2);

            Display(p);
        }
    }
}

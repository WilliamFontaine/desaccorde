using Modele;
using System;
using System.Collections.Generic;

namespace Test_Artiste
{
    class Program
    {
#pragma warning disable IDE0060 // Supprimer le paramètre inutilisé
        static void Main(string[] args)
#pragma warning restore IDE0060 // Supprimer le paramètre inutilisé
        {
            Console.WriteLine("Test des artistes");

            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Console.WriteLine(a1);
            Console.WriteLine("---------------");

            IEnumerable<Morceau> tracklist = new List<Morceau>()
            {
            new Morceau("Morceau1", a1, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Rap,""),
            new Morceau("Morceau2", a1, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Classique,""),
            new Morceau("Morceau3",a1, "1:40",new DateTime(2021, 4, 29), "/img", Genre.Rap,"")
            };

            Artiste a2 = new("Artiste 2", "desc 2", new DateTime(1999, 07, 28), "/img");
            Console.WriteLine(a2);
            Console.WriteLine("---------------");

            IEnumerable<Morceau> tracklist2 = new List<Morceau>()
            {
            new Morceau("Morceau0", a2, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Rap,""),
            new Morceau("Morceau1", a2, "3:04", new DateTime(2019, 10, 11), "/img", Genre.Classique,""),
            new Morceau("Morceau2",a2, "1:40",new DateTime(2021, 4, 29), "/img", Genre.Rap,"")
            };

            a2.AjouterListOeuvres(new List<Album>() { new("Album 1", "desc album 1", a2, "/img", new DateTime(2005, 04, 12), tracklist) }); ;

            Console.WriteLine("---------------");
            a2.AjouterOeuvre(new Album("Album 2", "desc album 2", a2, "/img", new DateTime(2006, 07, 13), tracklist));

            Console.WriteLine("---------------");

            a2.AjouterListOeuvres(new List<Morceau>() { new("Morceau 1", a2, "3:29", new DateTime(2006, 07, 13), "/img", Genre.Rock, "") });

            Console.WriteLine("---------------");
            a2.AjouterOeuvre(new Morceau("Morceau 2", a2, "3:24", new DateTime(2006, 07, 13), "/img", Genre.Country, ""));

            Console.WriteLine("---------------");
        }
    }
}

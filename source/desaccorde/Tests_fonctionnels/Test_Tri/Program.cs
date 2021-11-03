using Modele;
using System;
using System.Collections.Generic;

namespace Test_Tri
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test de la fonction de tri");

            Artiste a1 = new("Artiste 1", "desc 1", new DateTime(2001, 03, 16), "/img");
            Artiste a2 = new("Artiste 2", "desc 1", new DateTime(2003, 12, 16), "/img");
            Artiste a3 = new("Artiste 3", "desc 1", new DateTime(1998, 03, 16), "/img");
            Artiste a4 = new("Artiste 4", "desc 1", new DateTime(1987, 03, 16), "/img");

            IEnumerable<Morceau> tracklist = new List<Morceau>()
            {
            new Morceau("A_Morceau1", a1, "3:04", new DateTime(2019,10,11),  "/img",Genre.Rap,""),
            new Morceau("M_Morceau2", a2, "3:04", new DateTime(2019,10,11), "/img", Genre.Classique,""),
            new Morceau("A_Morceau3", a2, "1:40", new DateTime(2021,4,29), "/img", Genre.Rap,""),
            new Morceau("B_Morceau4", a3, "3:04", new DateTime(2006,10,01), "/img", Genre.Rock,""),
            new Morceau("A_Morceau5", a3, "2:24", new DateTime(2006,04,30), "/img", Genre.RnB,""),
            new Morceau("D_Morceau6", a1, "3:04", new DateTime(2007,01,01), "/img", Genre.Afro,""),
            new Morceau("C_Morceau7", a2, "1:40", new DateTime(2010,10,11), "/img", Genre.Folk,""),
            new Morceau("C_Morceau8", a2, "3:54", new DateTime(2020,06,07), "/img", Genre.Country,""),
            new Morceau("E_Morceau9", a1, "3:04", new DateTime(2021,11,01), "/img", Genre.Punk,""),
            new Morceau("J_Morceau10", a2, "1:40", new DateTime(2018,01,04), "/img", Genre.Metal,""),
            new Morceau("S_Morceau11", a3, "2:04", new DateTime(2021,11,01), "/img", Genre.Blues,""),
            new Morceau("D_Morceau12", a1, "3:34", new DateTime(2020,10,21), "/img", Genre.Jazz,""),
            new Morceau("F_Morceau13", a2, "1:40", new DateTime(2001,01,01), "/img", Genre.Kpop,"")
            };

            Console.WriteLine("Tri Alphabétique");

            ITri<Morceau> trieur1 = new TriAlphabetiqueMorceau();

            foreach (Morceau m in trieur1.Tri(tracklist))
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Tri Artiste");

            ITri<Morceau> trieur2 = new TriArtistesMorceau();

            foreach (Morceau m in trieur2.Tri(tracklist))
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("---------------");


            Console.WriteLine("Tri date");

            ITri<Morceau> trieur3 = new TriDates();

            foreach (Morceau m in trieur3.Tri(tracklist))
            {
                Console.Write(m);
                Console.WriteLine(m.Parution.ToString("dd/MM/yyyy"));
            }
        }
    }
}

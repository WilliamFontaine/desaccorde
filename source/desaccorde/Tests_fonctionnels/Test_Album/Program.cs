using Modele;
using System;
using System.Collections.Generic;

namespace Test_Album
{
    class Program
    {
        static void Display(Oeuvre e)
        {
            Album al = e as Album;
            foreach (Oeuvre o in al.Tracklist)
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
            Console.WriteLine("Test des albums");

            Artiste ar1 = new("Artiste 1", "desc artiste 1", new DateTime(2001, 03, 16), "/img");
            Oeuvre al1 = new Album("test1", "desc album 1", ar1, "/img", new DateTime(2021, 05, 11));
            Oeuvre al2 = new Album("test2", "desc album 2", ar1, "/img", new DateTime(2021, 05, 11));
            Oeuvre m1 = new Morceau("morceau 1", ar1, "3:21", new DateTime(2021, 05, 11), "/img", Genre.Rap, "");

            Album al11 = (al1 as Album);
            Album al21 = (al2 as Album);
            al21.AjouterListOeuvre(new List<Oeuvre>() { m1, m1, m1 });

            al11.AjouterOeuvre(m1);
            foreach (Oeuvre o in al11.Tracklist)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(al11.NbTitres);
            Console.WriteLine("---------------");
            al11.AjouterOeuvre(m1);
            al11.AjouterOeuvre(m1);
            al11.AjouterOeuvre(al2);

            Display(al11);

            Console.WriteLine(al11.NbTitres);
            Console.WriteLine("---------------");
            al11.SupprimerOeuvre(m1);
            al11.SupprimerOeuvre(m1);
            al11.SupprimerOeuvre(m1);
            al11.SupprimerOeuvre(m1);
            foreach (Oeuvre o in al11.Tracklist)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine(al11.NbTitres);
        }
    }
}

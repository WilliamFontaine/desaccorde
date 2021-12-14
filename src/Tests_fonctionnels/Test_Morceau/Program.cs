using Modele;
using System;
using System.Collections.Generic;

namespace Test_Morceau
{
    class Program
    {
#pragma warning disable IDE0060 // Supprimer le paramètre inutilisé
        static void Main(string[] args)
#pragma warning restore IDE0060 // Supprimer le paramètre inutilisé
        {
            Console.WriteLine("Test des morceaux :");

            Artiste test = new("Vald", "Vald, de son vrai nom Valentin Le Du, né le 15 juillet 1992 à Aulnay - " +
                "sous - Bois, en Seine - Saint - Denis, est un rappeur et parolier français.Après deux mixtapes et deux EPs, " +
                "il sort son premier album studio Agartha le 20 janvier 2017 suivi de XEU, le 2 février 2018, puis son troisième album studio Ce " +
                "monde est cruel en 2019.Début 2020, Vald crée son label indépendant: Echelon Music.", new DateTime(1992, 07, 15), "/img");
            Artiste test2 = new("Seezy", "Seezy, de son vrai nom Samuel Taieb, est un producteur et réalisateur artistique français originaire d’Évry," +
                " dans l'Essonne, né le 18 mars 1997 et signé chez le label français Capitol Music.", new DateTime(1997, 03, 18), "/img");


            List<Artiste> feat = new() { test2 };

            Morceau m1 = new("morceau1", test, "3:20", new DateTime(2019, 10, 10), "/img", Genre.Rap, "");
            Morceau m2 = new("morceau2", test, "2:42", new DateTime(2019, 10, 10), "/img", feat, Genre.Metal, "");

            feat.Add(test2);

            Morceau m3 = new("morceau2", test, "2:42", new DateTime(2019, 10, 10), "/img", feat, Genre.Metal, "");

            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m3);
        }

    }
}
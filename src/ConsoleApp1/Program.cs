using Modele;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program : IPersistanceManager
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public (IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis) ChargeDonnees()
        {
            throw new NotImplementedException();
        }

        public void SauvegardeDonnees(IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis)
        {
            throw new NotImplementedException();
        }
    }
}

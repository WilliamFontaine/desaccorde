using System;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Manger d' <see cref="Artiste"/>
    /// </summary>
    public partial class Manager
    {
        /// <summary>
        /// Méthode pour ajouter un <see cref="Artiste"/> à la liste d'<see cref="Artiste"/> de l'application
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="description">string</param>
        /// <param name="dateNaissance">DateTime</param> 
        /// <returns>false si l'artiste est déjà dans la liste, sinon, retourne true et ajoute l'artiste dans la liste</returns>
        public bool AjouterArtiste(string nom, string description, DateTime dateNaissance, string image)
        {

            Artiste artiste = new(nom, description, dateNaissance, image);
            if (artistes.Contains(artiste))
            {
                return false;
            }
            artistes.Add(artiste);
            return true;
        }

        /// <summary>
        /// Méthode pour supprimer un <see cref="Artiste"/> de la liste de l'application
        /// </summary>
        /// <param name="a">Artiste</param>
        /// <returns>si l'artiste n'est pas dans la liste, retourne false, sinon, le supprime et rends true</returns>
        public bool SupprimerArtiste(Artiste a)
        {
            if (!artistes.Contains(a))
            {
                return false;
            }
            artistes.Remove(a);
            return true;
        }

        public Artiste GetArtiste(string nom)
        {
            return artistes.SingleOrDefault(n => n.Nom.Equals(nom));
        }
    }
}

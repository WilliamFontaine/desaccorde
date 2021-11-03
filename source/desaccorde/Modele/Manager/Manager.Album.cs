using System;

namespace Modele
{
    /// <summary>
    /// Manager d' <see cref="Album"/>
    /// </summary>
    public partial class Manager
    {
        /// <summary>
        /// Méthode d'ajout d'un <see cref="Album"/> à la liste d'<see cref="Oeuvre"/> de l'application
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="auteur">Artiste</param>
        /// <param name="parution">DateTime</param>
        /// <returns>false si l'album est déjà dans la liste, sinon, retourne true et ajoute l'album dans la liste</returns>
        public bool AjouterAlbum(string titre, string description, Artiste auteur, string image, DateTime parution)
        {
            Oeuvre album = new Album(titre, description, auteur, image, parution);
            if (oeuvres.Contains(album))
            {
                return false;
            }
            oeuvres.Add(album);
            return true;
        }

        /// <summary>
        /// Méthode de suppression d'un <see cref="Album"/> de la liste d'<see cref="Oeuvre"/>
        /// </summary>
        /// <param name="a">Album</param>
        /// <returns>si l'album n'est pas dans la liste, retourne false, sinon, le supprime et rends true</returns>
        public bool Supprimeralbum(Album a)
        {
            if (!oeuvres.Contains(a))
            {
                return false;
            }
            oeuvres.Remove(a);
            return true;
        }
    }
}

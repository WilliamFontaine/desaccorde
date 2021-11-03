using System;

namespace Modele
{
    /// <summary>
    /// Manager d'un Morceau
    /// </summary>
    public partial class Manager
    {
        /// <summary>
        /// Méthode pour ajouter un <see cref="Morceau"/> à la liste d'<see cref="Oeuvre"/> de l'appliction
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="auteur">Artiste</param>
        /// <param name="duree">string</param>
        /// <param name="parution">DateTime</param>
        /// <param name="genre">Genre</param>
        /// <returns>false si le morceau est déjà dans la liste, sinon, retourne true et ajoute le morceau dans la liste</returns>
        public bool AjouterMorceau(string titre, Artiste auteur, string duree, string image, DateTime parution, Genre genre, string audio)
        {
            Oeuvre morceau = new Morceau(titre, auteur, duree, parution, image, genre, audio);
            if (oeuvres.Contains(morceau))
            {
                return false;
            }
            oeuvres.Add(morceau);
            return true;
        }

        /// <summary>
        /// Méthode pour supprimer un <see cref="Morceau"/> de la liste de l'application
        /// </summary>
        /// <param name="m">Morceau</param>
        /// <returns>si le morceau n'est pas dans la liste, retourne false, sinon, le supprime et rends true</returns>
        public bool SupprimerMorceau(Morceau m)
        {
            if (!oeuvres.Contains(m))
            {
                return false;
            }
            oeuvres.Remove(m);
            return true;
        }
    }
}

using System.Collections.Generic;

namespace Modele
{
    /// <summary>
    /// Manager de recherche
    /// </summary>
    public partial class Manager
    {
        readonly IRecherche<Album> rechercheurAlbum = new RechercheAlbum();
        readonly IRecherche<Artiste> rechercheurArtiste = new RechercheArtiste();
        readonly IRecherche<Morceau> rechercheurMorceau = new RechercheMorceau();
        readonly IRecherche<Morceau> rechercheurGenre = new RechercheGenre();

        /// <summary>
        /// Méthode appelant la recherche d'<see cref="Artiste"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Resultat de la recherche d'artiste</returns>
        public IEnumerable<Artiste> RechercheArtiste(string value)
        {
            List<Artiste> listArtiste = new();
            return rechercheurArtiste.Rechercher(artistes, value);
        }

        /// <summary>
        /// Méthode appelant la recherche d'<see cref="Album"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Resultat de la recherche d'album</returns>
        public IEnumerable<Album> RechercheAlbum(string value)
        {
            List<Album> listAlbum = new();
            foreach (Oeuvre o in oeuvres)
            {
                if (o is Album)
                {
                    listAlbum.Add(o as Album);
                }
            }
            return rechercheurAlbum.Rechercher(listAlbum, value);
        }

        /// <summary>
        /// Méthode appelant la recherche de <see cref="Morceau"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Resultat de la recherche de Morceau</returns>
        public IEnumerable<Morceau> RechercheMorceau(string value)
        {
            List<Morceau> listMorceau = new();
            foreach (Oeuvre o in oeuvres)
            {
                if (o is Morceau)
                {
                    listMorceau.Add(o as Morceau);
                }
            }
            return rechercheurMorceau.Rechercher(listMorceau, value);
        }


        /// <summary>
        /// Méthode appelant la recherche de <see cref="Morceau"/> par Genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>Liste de morceau selon le genre recherché</returns>
        public IEnumerable<Morceau> RechercherGenre(string genre)
        {
            List<Morceau> listMorceau = new();
            foreach (Oeuvre o in oeuvres)
            {
                if (o is Morceau)
                {
                    listMorceau.Add(o as Morceau);
                }
            }

            return rechercheurGenre.Rechercher(listMorceau, genre);
        }
    }
}

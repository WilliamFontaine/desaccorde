using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Recherche par <see cref="Album"/>
    /// </summary>
    public class RechercheAlbum : IRecherche<Album>
    {
        /// <summary>
        /// Méthode de recherche par <see cref="Album"/>
        /// </summary>
        /// <param name="albums"></param>
        /// <param name="value"></param>
        /// <returns>Retourne la collection d'<see cref="Album"/> recherchée et triée</returns>
        public IEnumerable<Album> Rechercher(IEnumerable<Album> albums, string value)
        {
            return albums.Where(n => n.Titre.ToLower().Contains(value.ToLower())).OrderBy(n => n.Titre);
        }
    }
}

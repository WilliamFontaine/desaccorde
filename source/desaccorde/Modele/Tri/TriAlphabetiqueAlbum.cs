using System.Collections.Generic;
using System.Linq;

namespace Modele.Tri
{
    /// <summary>
    /// Tri d'une collection d'<see cref="Album"/>
    /// </summary>
    public class TriAlphabetiqueAlbum : ITri<Album>
    {

        /// <summary>
        /// Méthode de tri de <see cref="Album"/> par titre
        /// </summary>
        /// <param name="albums"></param>
        /// <returns>Retourne une collection de <see cref="Album"/> triée pas titre</returns>
        public IEnumerable<Album> Tri(IEnumerable<Album> albums)
        {
            return albums.OrderBy(n => n.Titre);
        }

    }
}

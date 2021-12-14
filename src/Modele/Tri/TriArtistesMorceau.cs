using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Tri d'une d'une collection de <see cref="Morceau"/> par <see cref="Artiste"/>
    /// </summary>
    public class TriArtistesMorceau : ITri<Morceau>
    {
        /// <summary>
        /// Méthode tri par <see cref="Artiste"/> puis par titre
        /// </summary>
        /// <param name="morceaux"></param>
        /// <returns>Retourne la collection triée par artiste</returns>
        public IEnumerable<Morceau> Tri(IEnumerable<Morceau> morceaux)
        {
            return morceaux.OrderBy(n => n.Auteur).ThenBy(n => n.Titre);
        }
    }
}

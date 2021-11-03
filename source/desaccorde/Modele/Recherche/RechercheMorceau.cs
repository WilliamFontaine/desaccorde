using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Recherhce par <see cref="Morceau"/>
    /// </summary>
    public class RechercheMorceau : IRecherche<Morceau>
    {
        /// <summary>
        /// Méthode de recherche par <see cref="Morceau"/>
        /// </summary>
        /// <param name="morceaux"></param>
        /// <param name="value"></param>
        /// <returns>Retourne le resultat de la recherche dans un collection de <see cref="Morceau"/> triée</returns>
        public IEnumerable<Morceau> Rechercher(IEnumerable<Morceau> morceaux, string value)
        {
            return morceaux.Where(n => n.Titre.ToLower().Contains(value.ToLower())).OrderBy(n => n.Titre);
        }
    }
}

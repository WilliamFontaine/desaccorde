using System;
using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Recherche par <see cref="Genre"/>
    /// </summary>
    public class RechercheGenre : IRecherche<Morceau>
    {
        /// <summary>
        /// Méthode de recherche par <see cref="Genre"/>
        /// </summary>
        /// <param name="morceaux"></param>
        /// <param name="value"></param>
        /// <returns>Retourne le resultat de la recherche dans une collection de <see cref="Morceaux"/> triée</returns>
        public IEnumerable<Morceau> Rechercher(IEnumerable<Morceau> morceaux, string value)
        {
            return morceaux.Where(n => n.Genre.Equals((Genre)Enum.Parse(typeof(Genre), value))).OrderBy(n => n.Titre);
        }
    }
}

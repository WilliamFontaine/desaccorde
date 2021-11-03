using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Recherche par <see cref="Artiste"/>
    /// </summary>
    public class RechercheArtiste : IRecherche<Artiste>
    {
        /// <summary>
        /// Méthode de recherche par <see cref="Artiste"/>
        /// </summary>
        /// <param name="artistes"></param>
        /// <param name="value"></param>
        /// <returns>Retourne le resultat de la recherche dans une collection d'<see cref="Artiste"/> triée</returns>
        public IEnumerable<Artiste> Rechercher(IEnumerable<Artiste> artistes, string value)
        {
            return artistes.Where(n => n.Nom.ToLower().Contains(value.ToLower())).OrderBy(n => n.Nom);
        }
    }
}

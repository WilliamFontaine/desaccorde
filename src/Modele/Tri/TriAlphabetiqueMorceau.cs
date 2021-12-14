using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    ///<summary>
    /// Tri d'une collection de <see cref="Morceau"/> par ordre alphabétique
    /// </summary>
    public class TriAlphabetiqueMorceau : ITri<Morceau>
    {
        /// <summary>
        /// Méthode de tri de <see cref="Morceau"/> par titre
        /// </summary>
        /// <param name="oeuvres"></param>
        /// <returns>Retourne une collection de <see cref="Morceau"/> triée pas titre</returns>
        public IEnumerable<Morceau> Tri(IEnumerable<Morceau> morceaux)
        {
            return morceaux.OrderBy(n => n.Titre);
        }
    }
}

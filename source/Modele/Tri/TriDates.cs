using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Tri d'une collection de <see cref="Morceau"/> par date
    /// </summary>
    public class TriDates : ITri<Morceau>
    {
        /// <summary>
        /// Méthode de tri des <see cref="Morceau"/> par date de parution
        /// </summary>
        /// <param name="morceaux"></param>
        /// <returns>la collection triée par date</returns>
        public IEnumerable<Morceau> Tri(IEnumerable<Morceau> morceaux)
        {
            return morceaux.OrderBy(n => n.Parution).ThenBy(n => n.Titre);
        }
    }
}

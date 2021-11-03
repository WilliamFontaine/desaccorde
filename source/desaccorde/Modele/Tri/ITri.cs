using System.Collections.Generic;

namespace Modele
{
    /// <summary>
    /// Interface de tri générale
    /// </summary>
    public interface ITri<T>
    {
        /// <summary>
        /// Méthode générale de tri
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Retourne une collection triée</returns>
        public abstract IEnumerable<T> Tri(IEnumerable<T> items);
    }
}
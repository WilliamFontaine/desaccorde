using System.Collections.Generic;

namespace Modele
{
    /// <summary>
    /// Interface de recherche des <see cref="Morceau"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRecherche<T>
    {
        /// <summary>
        /// Méthode de recherche général
        /// </summary>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <returns>Retourne la collection triée</returns>
        public abstract IEnumerable<T> Rechercher(IEnumerable<T> items, string value);
    }

}

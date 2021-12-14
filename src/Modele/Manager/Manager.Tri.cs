using System.Collections.Generic;

namespace Modele
{
    /// <summary>
    /// Manager de tri
    /// </summary>
    public partial class Manager
    {
        readonly ITri<Morceau> trieurDateAsc = new TriDates();
        readonly ITri<Morceau> trieurArtistesAsc = new TriArtistesMorceau();
        readonly ITri<Morceau> trieurMorceauAsc = new TriAlphabetiqueMorceau();

        /// <summary>
        /// tri par date
        /// </summary>
        /// <returns>Liste d'oeuvres triée</returns>
        public IEnumerable<Morceau> TriDateAsc(IEnumerable<Morceau> m)
        {
            return trieurDateAsc.Tri(m);
        }

        /// <summary>
        /// tri par <see cref="Artiste"/>
        /// </summary>
        /// <returns>Liste d'oeuvres triée</returns>
        public IEnumerable<Morceau> TriArtisteAsc(IEnumerable<Morceau> m)
        {
            return trieurArtistesAsc.Tri(m);
        }

        /// <summary>
        /// tri par <see cref="Morceau"/>
        /// </summary>
        /// <returns>Liste d'oeuvres triée</returns>
        public IEnumerable<Morceau> TriTitreAsc(IEnumerable<Morceau> m)
        {
            return trieurMorceauAsc.Tri(m);
        }
    }
}

using System.Collections.Generic;

namespace Modele
{
    /// <summary>
    /// Persistance du manager
    /// </summary>
    public interface IPersistanceManager
    {
        (IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis) ChargeDonnees();

        void SauvegardeDonnees(IEnumerable<Artiste> artistes, IEnumerable<Album> albums, IEnumerable<Morceau> morceaux, IEnumerable<Utilisateur> utilisateurs, Utilisateur currentUser, Dictionary<Oeuvre, List<Avis>> avis);
    }
}

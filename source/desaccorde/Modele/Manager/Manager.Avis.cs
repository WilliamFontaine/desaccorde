using System;
using System.Collections.Generic;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Manager d' <see cref="Avis"/>
    /// </summary>
    public partial class Manager
    {

        /// <summary>
        /// Methode pour noter une <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="o">Oeuvre</param>
        /// <param name="commentaire">string</param>
        /// <param name="type">Type</param>
        public void Noter(Oeuvre o, Type type)
        {
            string commentaire = null;
            Avis avis = new(commentaire, CurrentUser, type);

            if (!IsConnecte())
            {
                throw new NullReferenceException("Aucun utilisateur n'est connecté !");
            }
            if (!appreciations.ContainsKey(o))
            {
                appreciations.Add(o, new List<Avis>() { avis });
            }
            List<Avis> result = new();
            appreciations.TryGetValue(o, out result);
            if (result.Exists(n => n.User.Equals(CurrentUser)))
            {
                foreach (Avis a in result)
                {
                    if (a.User.Equals(CurrentUser))
                    {
                        a.Type = type;
                    }
                }
            }
            else
            {
                result.Add(avis);
            }
        }

        /// <summary>
        /// Méthode pour commenter une <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="o"></param>
        /// <param name="commentaire"></param>
        public void Commenter(Oeuvre o, string commentaire)
        {
            Type type = Type.Defaut;
            Avis avis = new(commentaire, CurrentUser, type);

            if (!IsConnecte())
            {
                throw new NullReferenceException("Aucun utilisateur n'est connecté !");
            }
            if (!appreciations.ContainsKey(o))
            {
                appreciations.Add(o, new List<Avis>());
            }
            List<Avis> result = new();
            appreciations.TryGetValue(o, out result);
            if (result.Exists(n => n.User.Equals(CurrentUser)))
            {
                foreach (Avis a in result)
                {
                    if (a.User.Equals(CurrentUser))
                    {
                        a.Commentaire = commentaire;
                    }
                }
            }
            else
            {
                result.Add(avis);
            }
        }

        /// <summary>
        /// Methode qui compte le nombre de likes d'une oeuvre
        /// </summary>
        /// <param name="o">Oeuvre</param>
        /// <returns></returns>
        public int GetNbLikes(Oeuvre o)
        {
            List<Avis> result = new();
            appreciations.TryGetValue(o, out result);
            if (result == null) return 0;
            return result.Count(n => n.Type.Equals((Type)Enum.Parse(typeof(Type), "Like")));
        }

        /// <summary>
        ///  Methode de suppression de l'unique avis de l'utilisateur sur le morceau courant
        /// </summary>
        public void SupprimerAvisMorceau()
        {
            if (CurrentUser == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                appreciations.TryGetValue(CurrentMorceau, out List<Avis> avis);
                avis.Remove(avis.SingleOrDefault(a => a.User.Equals(CurrentUser)));
            }
        }

        /// <summary>
        /// Méthode de suppression de l'unique avis de l'utilisateur courant sur l'album courant
        /// </summary>
        public void SupprimerAvisAlbum()
        {
            if (CurrentUser == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                appreciations.TryGetValue(CurrentAlbum, out List<Avis> avis);
                avis.Remove(avis.SingleOrDefault(a => a.User.Equals(CurrentUser)));
            }
        }
    }
}

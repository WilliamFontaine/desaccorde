using System;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Manager d'Utilisateur
    /// </summary>
    public partial class Manager
    {
        /// <summary>
        /// Méthode d'ajout d'un <see cref="Utilisateur"/>
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="prenom">string</param>
        /// <param name="pseudo">string</param>
        /// <param name="ddn">DateTime</param>
        /// <param name="email">string</param>
        /// <param name="mdp">string</param>
        /// /// <returns>false si l'utilisateur est déjà dans la liste, sinon, retourne true et ajoute l'utilisateur dans la liste</returns>
        public bool AjouterUtilisateur(string nom, string prenom, string pseudo, DateTime ddn, string email, string mdp, string image)
        {
            Utilisateur user = new(nom, prenom, pseudo, ddn, email, mdp, image);
            if (users.Contains(user))
            {
                return false;
            }
            users.Add(user);
            return true;
        }

        /// <summary>
        /// Méthode se suppression d'un <see cref="Utilisateur"/>
        /// </summary>
        /// <param name="user">Utilisateur</param>
        /// <returns>si l'utilisateur n'est pas dans la liste, retourne false, sinon, le supprime et rends true</returns>
        public bool SupprimerUtilisateur(Utilisateur user)
        {
            if (!users.Contains(user))
            {
                return false;
            }
            users.Remove(user);
            return true;

        }

        /// <summary>
        /// Méthode pour changer l'<see cref="Utilisateur"/> actuel, se connecter en temps qu'<see cref="Utilisateur"/> actuel
        /// </summary>
        /// <param name="mdp">string</param>
        /// <param name="email">string</param>
        public bool SeConnecter(string email, string mdp)
        {

            //var select = users.Select(n => n.Email.Equals(email) && n.MotDePasse.Equals(mdp));
            foreach (Utilisateur u in users)
            {
                if (u.Email.Equals(email) && u.MotDePasse.Equals(mdp))
                {
                    CurrentUser = u;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Méthode pour ne plus avoir d'<see cref="Utilisateur"/> actuel
        /// </summary>
        public void SeDeconnecter()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// Methode pour modifier un utilisateur
        /// </summary>
        /// <param name="old">ancien utilisateur</param>
        /// <param name="newU">nouvel utilisateur</param>
        /// <returns></returns>
        public Utilisateur ModifierUtilisateur(Utilisateur oldU, Utilisateur newU)
        {
            System.Type typeUtilisateur = typeof(Utilisateur);
            var UtilisateurProprietes = typeUtilisateur.GetProperties();
            if (oldU.Equals(newU))
            {
                oldU.Pseudo = newU.Pseudo;
                oldU.MotDePasse = newU.MotDePasse;
                oldU.Image = newU.Image;
                return oldU;
            }
            if (Utilisateurs.Any(u => u.Equals(newU)))
            {
                throw new ArgumentException("Un Utilisateur existe deja avec ces identifiants !");
            }
            oldU.Pseudo = newU.Pseudo;
            oldU.MotDePasse = newU.MotDePasse;
            oldU.Image = newU.Image;
            return oldU;
        }

        /// <summary>
        /// Verifie si un utilisateur est connecté
        /// </summary>
        /// <returns>Retourne true si l'utilisateur est connecté sinon false</returns>
        public bool IsConnecte()
        {
            if (CurrentUser is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

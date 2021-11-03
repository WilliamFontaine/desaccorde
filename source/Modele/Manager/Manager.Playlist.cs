using System;
using System.Linq;

namespace Modele
{
    /// <summary>
    /// Manager d'une Playlist
    /// </summary>
    public partial class Manager
    {
        /// <summary>
        /// Méthode de création d'un <see cref="Playlist"/> dans la liste de <see cref="Playlist"/> de l'application
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <returns>false si la playlist est déjà dans la liste, sinon, retourne true et ajoute la playlist dans la liste</returns>
        public bool AjouterPlaylist(string titre, string description, string image)
        {
            if (!IsConnecte())
            {
                throw new NullReferenceException("L'utilisateur doit être connecté pour ajouter une playlist");
            }
            Playlist playlist = new(titre, description, image);
            if (playlists.Contains(playlist))
            {
                return false;
            }
            playlists.Add(playlist);
            return true;
        }

        /// <summary>
        /// Méthode de suppression d'une <see cref="Playlist"/> de la liste de <see cref="Playlist"/> de l'application
        /// </summary>
        /// <param name="p">Playlist</param>
        /// <returns>si l'album n'est pas dans la liste, retourne false, sinon, le supprime et rends true</returns>
        public bool SupprimerPlaylist(Playlist p)
        {
            if (!IsConnecte())
            {
                throw new NullReferenceException("L'utilisateur doit être connecté pour supprimer une playlist");
            }
            if (!playlists.Contains(p))
            {
                return false;
            }
            playlists.Remove(p);
            return true;
        }

        /// <summary>
        /// Getter de la playlist utilisant Equals
        /// </summary>
        /// <param name="playlist"></param>
        /// <returns>La playlist equivalente </returns>
        public Playlist GetPlaylist(Playlist playlist)
        {
            return playlists.SingleOrDefault(p => p.Equals(playlist));
        }

        /// <summary>
        /// Second get de playlist avec seulement le titre
        /// </summary>
        /// <param name="titre"></param>
        /// <returns>la playlist demandée</returns>
        public Playlist GetPlaylist(string titre)
        {
            return playlists.SingleOrDefault(n => n.Titre.Equals(titre));
        }

        /// <summary>
        /// Methode pour modifier une playlist
        /// </summary>
        /// <param name="oldP">Ancienne playlist</param>
        /// <param name="newP">Nouvelle playlist</param>
        public Playlist ModifierPlaylist(Playlist oldP, Playlist newP)
        {
            System.Type typePlaylist = typeof(Playlist);
            var PlaylistProperties = typePlaylist.GetProperties();
            if (oldP.Equals(newP))
            {
                oldP.Titre = newP.Titre;
                oldP.Description = newP.Description;
                oldP.Image = newP.Image;
                return oldP;
            }
            if (CurrentUser.Playlists.Any(p => p.Titre.Equals(newP.Titre)))
            {
                throw new ArgumentException("Une playlist possede deja ce nom !");
            }
            oldP.Titre = newP.Titre;
            oldP.Description = newP.Description;
            oldP.Image = newP.Image;
            return oldP;
        }


    }
}

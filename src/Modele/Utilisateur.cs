using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Modele
{
    /// <summary>
    /// représente un <see cref="Utilisateur"/>
    /// </summary>
    public class Utilisateur : IEquatable<Utilisateur>, IComparable<Utilisateur>, IComparable, INotifyPropertyChanged
    {

        [BsonId]
        public Guid Id { get; private set; }

        /// <summary>
        /// Nom d'un <see cref="Utilisateur"/>
        /// </summary>
        public string Nom
        {
            get
            {
                return nom;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Veuillez saisir votre nom.");
                }
                else nom = value;
            }
        }
        private string nom;

        /// <summary>
        /// Prénom d'un <see cref="Utilisateur"/>
        /// </summary>
        public string Prenom
        {
            get
            {
                return prenom;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Veuillez saisir votre prénom.");
                }
                else prenom = value;
            }
        }
        private string prenom;

        /// <summary>
        /// Pseudo d'un <see cref="Utilisateur"/>
        /// </summary>
        public string Pseudo
        {
            get
            {
                return pseudo;
            }
            set
            {
                pseudo = value;
            }
        }
        private string pseudo;

        /// <summary>
        /// Image d'un utilisateur
        /// </summary>
        public string Image
        {
            get;
            set;

        }

        /// <summary>
        /// Date de Naissance d'un <see cref="Utilisateur"/>
        /// </summary>
        public DateTime DateNaissance
        {
            get;
            private set;
        }


        /// <summary>

        /// Email d'un <see cref="Utilisateur"/>
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                email = value;
            }
        }
        private string email;

        /// <summary>
        /// Mot de passe d'un <see cref="Utilisateur"/>
        /// </summary>
        public string MotDePasse
        {
            get
            {
                return motDePasse;
            }
            set
            {
                motDePasse = value;
            }
        }
        private string motDePasse;

        /// <summary>
        /// Liste de playlists d'un <see cref="Utilisateur"/>
        /// </summary>
        [BsonIgnoreIfDefault]
        public Collection<Playlist> Playlists
        {
            get
            {
                return playlists;
            }
            set
            {
                OnPropertyChanged();
                playlists = value;
            }
        }
        private Collection<Playlist> playlists;


        /// <summary>
        /// Liste d'<see cref="Artiste"/> favoris d'un <see cref="Utilisateur"/>
        /// </summary>
        //public ReadOnlyCollection<Artiste> Artistes
        [BsonIgnoreIfDefault]
        public Collection<Artiste> Artistes
        {

            get
            {
                return artistes;
            }
            set
            {
                OnPropertyChanged();
                artistes = value;
            }
        }
        private Collection<Artiste> artistes;

        /// <summary>
        /// Liste d'albums d'un utilisateur
        /// </summary>
        /// 
        [BsonIgnoreIfDefault]
        public Collection<Album> Albums
        {
            get
            {
                return albums;
            }
            set
            {
                OnPropertyChanged();
                albums = value;
            }
        }
        private Collection<Album> albums;

        /// <summary>
        /// Liste du morceaux d'un utilisateur
        /// </summary>
        /// 
        [BsonIgnoreIfDefault]
        public Collection<Morceau> Morceaux
        {
            get
            {
                return morceaux;
            }
            set
            {
                OnPropertyChanged();
                morceaux = value;
            }
        }
        private Collection<Morceau> morceaux;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur d'un <see cref="Utilisateur"/>
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="prenom">string</param>
        /// <param name="pseudo">string</param>
        /// <param name="ddn">Datetime</param>
        /// <param name="email">string</param>
        /// <param name="mdp">string</param>
        public Utilisateur(string nom, string prenom, string pseudo, DateTime ddn, string email, string mdp, string image)
        {
            Nom = nom;
            Prenom = prenom;
            Pseudo = pseudo;
            DateNaissance = ddn;
            Email = email;
            MotDePasse = mdp;
            Image = image;
            Playlists = new();
            Artistes = new();
            Albums = new();
            Morceaux = new();
            //Playlists = new ReadOnlyCollection<Playlist>(playlists);
            //Artistes = new ReadOnlyCollection<Artiste>(artistes);
            //Albums = new ReadOnlyCollection<Album>(albums);
            //Morceaux = new ReadOnlyCollection<Morceau>(morceaux);
        }

        /// <summary>
        /// Méthode de création d'une <see cref="Playlist"/> dans la liste de <see cref="Playlist"/> de l'<see cref="Utilisateur"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        public void AjouterPlaylist(string titre, string description, string image)
        {
            Playlist playlist = new(titre, description, image);
            if (Playlists.Contains(playlist))
            {
                throw new ArgumentException("Une autre playlist porte déjà ce nom.");
            }
            Playlists.Add(playlist);
            OnPropertyChanged();
        }

        /// <summary>
        /// Méthode de suppression d'un <see cref="Playlist"/> de la liste de <see cref="Playlist"/> de l'<see cref="Utilisateur"/>
        /// </summary>
        /// <param name="p">Playlist</param>
        public void SupprimerPlaylist(Playlist p)
        {
            Playlists.Remove(p);
            OnPropertyChanged();
        }

        /// <summary
        /// Méthode d'ajout d'un <see cref="Oeuvre"/> dans les favoris
        /// </summary>
        /// <param name="o">Oeuvre</param>
        public void AjouterOeuvre(Oeuvre o)
        {
            if (o is Album)
            {
                if (Albums.Contains(o as Album))
                {
                    throw new ArgumentException("Cet album est déjà en favoris.");
                }
                else
                {
                    Albums.Add(o as Album);
                }
            }
            else
            {
                if (Morceaux.Contains(o as Morceau))
                {
                    throw new ArgumentException("Ce morceau est déjà en favoris.");
                }
                else
                {
                    Morceaux.Add(o as Morceau);
                }
            }
        }

        /// <summary>
        /// Méthode de suppression d'un <see cref="Oeuvre"/> dans les favoris
        /// </summary>
        /// <param name="o">Oeuvre</param>
        public void SupprimerOeuvre(Oeuvre o)
        {
            if (o is Album)
            {
                if (!Albums.Contains(o as Album))
                {
                    throw new ArgumentException("Cet album n'est pas en favoris.");
                }
                else
                {
                    Albums.Remove(o as Album);
                }
            }
            else
            {
                if (!Morceaux.Contains(o as Morceau))
                {
                    throw new ArgumentException("Ce morceau n'est pas en favoris.");
                }
                else
                {
                    Morceaux.Remove(o as Morceau);
                }
            }
        }

        /// <summary>
        /// Méthode d'ajout d'un <see cref="Artiste"/> dans les favoris
        /// </summary>
        /// <param name="a">Artiste</param>
        public void AjouterArtiste(Artiste a)
        {
            if (Artistes.Contains(a))
            {
                throw new ArgumentException("Cet Artiste est déjà en favoris.");
            }
            Artistes.Add(a);
        }

        /// <summary>
        /// Méthode de suppression d'un <see cref="Artiste"/> dans les favoris
        /// </summary>
        /// <param name="a">Artiste</param>
        public void SupprimerArtiste(Artiste a)
        {
            if (!Artistes.Contains(a))
            {
                throw new ArgumentException("Cet Artiste n'est pas en favoris.");
            }
            Artistes.Remove(a);
        }

        /// <summary>
        /// Méthode GetPlaylist
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(string titre)
        {
            return Playlists.SingleOrDefault(n => n.Titre.Equals(titre));
        }

        /// <summary>
        /// ToString de l'utilisateur
        /// </summary>
        /// <returns>le pseudo seulement</returns>
        public override string ToString()
        {
            return $"{Pseudo}, {Nom}";
        }

        /// <summary>
        /// Méthode <see cref="Equals"/>
        /// </summary>
        /// <param name="other">Utilisateur</param>
        /// <returns>retourne le résultat concaténé des Equals de Nom, Prenom, email et MotDepasse</returns>
        public bool Equals(Utilisateur other)
        {
            return Email.Equals(other.Email);
        }

        /// <summary>
        /// Méthode <see cref="Equals"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retourne true/false selon les tests d'egalités</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Utilisateur);
        }

        /// <summary>
        /// Méthode <see cref="GetHashCode"/>
        /// </summary>
        /// <returns>Retourne la concaténation des HashCode de Titre, Prenom et DateNaissance</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode() + Prenom.GetHashCode() + DateNaissance.GetHashCode();
        }

        /// <summary>
        /// Méthode <see cref="CompareTo"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne le CompareTo de obj casté en Utilisateur</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Utilisateur))
            {
                throw new ArgumentException("Ce n'est pas un utilisateur.", nameof(obj));
            }

            Utilisateur otherUtilisateur = obj as Utilisateur;
            return this.CompareTo(otherUtilisateur);
        }

        /// <summary>
        /// Méthode <see cref="CompareTo"/>
        /// </summary>
        /// <param name="other">Utilisateur</param>
        /// <returns>Retourne le résultat de CompareTo du Pseudo</returns>
        public int CompareTo(Utilisateur other)
        {
            return Pseudo.CompareTo(other.Pseudo);
        }
    }
}

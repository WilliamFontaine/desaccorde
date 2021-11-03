using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Modele
{
    /// <summary>
    /// représente une <see cref="Playlist"/> contenant des <see cref="Oeuvre"/>
    /// </summary>
    public class Playlist : IEquatable<Playlist>, IComparable<Playlist>, IComparable, INotifyPropertyChanged
    {
        [BsonId]
        public Guid Id { get; set; }

        ///<summary>
        /// Nom de la <see cref="Playlist"/>
        /// </summary>
        public string Titre
        {
            get => titre;
            set
            {
                if (titre == value) return;
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Une Playlist doit avoir un titre.");
                }
                titre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Self));
            }
        }
        private string titre;

        /// <summary>
        /// Description de la <see cref="Playlist"/>
        /// </summary>
        public string Description
        {
            get => description;
            set
            {
                if (description == value) return;
                description = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Self));
            }
        }
        private string description;

        /// <summary>
        /// Image d'une oeuvre
        /// </summary>
        public string Image
        {
            get => image;
            set
            {
                if (image == value) return;
                image = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Self));
            }
        }
        private string image;

        /// <summary>
        /// Date de creation de la <see cref="Playlist"/>
        /// </summary>
        public DateTime DateCreation
        {
            get;
            private set;
        }

        /// <summary>
        /// Propriété calculée retournant le nombre d'<see cref="Oeuvre"/> d'une <see cref="Playlist"/>
        /// </summary>
        public int NbOeuvres
        {
            get => Albums.Count + Morceaux.Count;
        }

        public Playlist Self => this;


        /// <summary>
        /// Albums d'une playlist
        /// Albums d'une playlist
        /// </summary>
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
        /// Morceaux d'une playlist
        /// </summary>
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
        /// Ajout d'une <see cref="Oeuvre"/> à une <see cref="Playlist"/>
        /// </summary>
        /// <param name="oeuvre">Oeuvre</param>
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
        /// Ajout d'un liste d' <see cref="Oeuvre"/> à une <see cref="Playlist"/>
        /// </summary>
        /// <param name="oeuvres">Oeuvre</param>
        public void AjouterListOeuvres(IEnumerable<Oeuvre> oeuvres)
        {
            foreach (Oeuvre o in oeuvres)
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
        }

        /// <summary>
        /// Supprimer un <see cref="Oeuvre"/> d'une <see cref="Playlist"/>
        /// </summary>
        /// <param name="oeuvres">Oeuvre</param>
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
        /// constructeur d'une <see cref="Playlist"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        public Playlist(string titre, string description, string image)
        {
            Titre = titre;
            Description = description;
            Image = image;
            DateCreation = DateTime.Now;
            Albums = new();
            Morceaux = new();
        }

        /// <summary>
        /// Constructeur d'une <see cref="Playlist"/> avec un Ienumerable d' <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="tracklist">IEnumerable<Morceau></param>
        public Playlist(string titre, string description, string image, IEnumerable<Oeuvre> morceaux, IEnumerable<Oeuvre> albums)
            : this(titre, description, image)
        {
            AjouterListOeuvres(morceaux);
            AjouterListOeuvres(albums);
        }

        /// <summary>
        /// Constructeur  d'une <see cref="Playlist"/> avec un <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="morceau">Oeuvre</param>
        public Playlist(string titre, string description, string image, Oeuvre oeuvre)
            : this(titre, description, image)
        {
            AjouterOeuvre(oeuvre);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Titre}";
        }


        /// <summary>
        /// Méthod Equals
        /// </summary>
        /// <param name="other">Playlist</param>
        /// <returns>Retourne le résultat du Equlas du Titre</returns>
        public bool Equals(Playlist other)
        {
            return Titre.Equals(other.Titre);
        }

        /// <summary>
        /// Méthode equals d'une <see cref="Playlist"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne true/false selon les tests d'egalités</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Playlist);
        }

        /// <summary>
        /// Méthode GetHashCode d'une <see cref="Playlist"/>
        /// </summary>
        /// <returns>Retourne le HashCode de Titre</returns>
        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }

        /// <summary>
        /// Méthode CompareTo d'une <see cref="Playlist"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne le CompareTo de obj casté en Playlist</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Utilisateur))
            {
                throw new ArgumentException("Ce n'est pas une playlist.", nameof(obj));
            }

            Playlist otherPlaylist = obj as Playlist;
            return this.CompareTo(otherPlaylist);
        }

        /// <summary>
        /// Méthode CompareTo
        /// </summary>
        /// <param name="other">Playlist</param>
        /// <returns>Retourne le résultat de CompareTo du Titre</returns>
        public int CompareTo(Playlist other)
        {
            return Titre.CompareTo(other.Titre);
        }

    }
}

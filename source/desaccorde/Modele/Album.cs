using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modele
{
    /// <summary>
    /// Représente un <see cref="Album"/>
    /// </summary>
    public class Album : Oeuvre, IEquatable<Album>, IComparable<Album>, IComparable
    {
        /// <summary>
        /// Description de l'<see cref="Album"/>
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Un album doit avoir une description.");
                }
                else description = value;
            }
        }

        private string description;

        /// <summary>
        /// Propriété calculée retournant le nombre de titres d'un <see cref="Album"/>
        /// </summary>
        public int NbTitres
        {
            get => Tracklist.Count;
        }

        /// <summary>
        /// Tracklist d'un <see cref="Album"/>
        /// </summary>
        public ReadOnlyCollection<Oeuvre> Tracklist
        {
            get;
            private set;
        }
        List<Oeuvre> tracklist = new();

        /// <summary>
        /// Methode pour ajouter une <see cref="Oeuvre"/> a l'<see cref="Album"/>
        /// </summary>
        /// <param name="o">Oeuvre</param>
        public void AjouterOeuvre(Oeuvre o)
        {
            tracklist.Add(o);
        }

        /// <summary>
        /// Méthode d'ajout d'une liste de morceaux
        /// </summary>
        /// <param name="o">IEnumerable<Oeuvre></param>
        public void AjouterListOeuvre(IEnumerable<Oeuvre> o)
        {
            tracklist.AddRange(o);
        }

        /// <summary>
        /// Méthode de suppression d'une oeuvre d'un album
        /// </summary>
        /// <param name="o">Oeuvre</param>
        public void SupprimerOeuvre(Oeuvre o)
        {
            tracklist.Remove(o);
        }


        /// <summary>
        /// Constructeur par défaut d'un <see cref="Album"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="auteur">Artiste</param>
        /// <param name="parution">DateTime</param>
        public Album(string titre, string description, Artiste auteur, string image, DateTime parution)
            : base(titre, auteur, parution, image)
        {
            Description = description;
            Tracklist = new ReadOnlyCollection<Oeuvre>(tracklist);

        }

        /// <summary>
        /// Constructeur d'un <see cref="Album"/> ave un Ienumerable d'<see cref="Oeuvre"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="auteur">Artiste</param>
        /// <param name="parution">dateTime</param>
        /// <param name="oeuvres">IEnumerable<Oeuvre></param>
        public Album(string titre, string description, Artiste auteur, string image, DateTime parution, IEnumerable<Oeuvre> oeuvres)
            : this(titre, description, auteur, image, parution)
        {
            AjouterListOeuvre(oeuvres);
        }

        /// <summary>
        /// Constructeur d'un <see cref="Album"/> avec une <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="description">string</param>
        /// <param name="auteur">Artiste</param>
        /// <param name="parution">DateTime</param>
        /// <param name="oeuvre">Oeuvre</param>
        public Album(string titre, string description, Artiste auteur, string image, DateTime parution, Oeuvre oeuvre)
            : this(titre, description, auteur, image, parution)
        {
            AjouterOeuvre(oeuvre);
        }


        /// <summary>
        /// <see cref="ToString"/> de la classe <see cref="Album"/>
        /// </summary>
        /// <returns>Titre, date de parution et description suivi du nombre de titre</returns>
        public override string ToString()
        {
            return $"{Titre}, {Auteur}, {Description}";
        }

        /// <summary>
        /// Methode <see cref="Equals"/> d'un <see cref="Album"/>
        /// </summary>
        /// <param name="other">Album</param>
        /// <returns>retourne le resultat des equals de Titre et de l'Auteur</returns>
        public bool Equals(Album other)
        {
            return Titre.Equals(other.Titre) && Auteur.Equals(other.Auteur);
        }

        /// <summary>
        /// Méthode redefinie de <see cref="Equals"/>  d'un <see cref="Album"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne true/false selon les tests d'egalités</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Album);
        }

        /// <summary>
        /// Méthode <see cref="GetHashCode"/>  d'un <see cref="Album"/>
        /// </summary>
        /// <returns>Retourne le HashCode de Nom</returns>
        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }


        /// <summary>
        /// Méthode <see cref="CompareTo"/> de Icomparable  d'un <see cref="Album"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne le CompareTo de obj casté en Album</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Album))
            {
                throw new ArgumentException("Ce n'est pas un album", nameof(obj));
            }

            Album otherAlbum = obj as Album;
            return this.CompareTo(otherAlbum);
        }


        /// <summary>
        /// Méthode <see cref="CompareTo"/>  d'un <see cref="Album"/>
        /// </summary>
        /// <param name="other">Album</param>
        /// <returns>Retourne le résultat de CompareTo du Titre</returns>
        public int CompareTo(Album other)
        {
            return Titre.CompareTo(other.Titre);
        }
    }
}

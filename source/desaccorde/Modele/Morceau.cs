using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Modele
{
    /// <summary>
    /// représente un <see cref="Morceau"/>
    /// </summary>
    public class Morceau : Oeuvre, IEquatable<Morceau>, IComparable<Morceau>, IComparable
    {
        /// <summary>
        /// Duree du <see cref="Morceau"/>
        /// </summary>
        public string Duree
        {
            get
            {
                return duree;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La duree d'un morceau doit être renseignée.");
                }
                else duree = value;
            }
        }
        private string duree;

        /// <summary>
        /// <see cref="Artiste"/> en collaboration sur ce titre
        /// </summary>
        public ReadOnlyCollection<Artiste> Featuring
        {
            get;
            private set;
        }
        List<Artiste> feat = new();

        /// <summary>
        /// <see cref="Genre"/> du <see cref="Morceau"/>
        /// </summary>
        public Genre Genre
        {
            get;
            private set;
        }

        /// <summary>
        /// lien audio du morceau
        /// </summary>
        public string Audio { get; set; }

        /// <summary>
        /// Constructeur d'un <see cref="Morceau"/> sans <see cref="Artiste"/> en featuring
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="auteur">string</param>
        /// <param name="duree">string</param>
        /// <param name="parution">DateTime</param>
        /// <param name="genre">Genre</param>
        public Morceau(string titre, Artiste auteur, string duree, DateTime parution, string image, Genre genre, string audio)
            : base(titre, auteur, parution, image)
        {
            Duree = duree;
            Genre = genre;
            Audio = audio;
        }

        /// <summary>
        /// Constructeur de <see cref="Morceau"/>
        /// </summary>
        /// <param name="titre">titre du morceau, string</param>
        /// <param name="auteur">auteur du morceau, string</param>
        /// <param name="duree">duree du morceau, string</param>
        /// <param name="parution">date de parution du morceau, DateTime</param>
        /// <param name="featuring">Artiste(s) en featuring, IEnumerable<Artiste></param>
        /// <param name="genre">Genre du morceau, Genre</param>
        public Morceau(string titre, Artiste auteur, string duree, DateTime parution, string image, IEnumerable<Artiste> featuring, Genre genre, string audio)
            : this(titre, auteur, duree, parution, image, genre, audio)
        {
            Featuring = new ReadOnlyCollection<Artiste>(feat);
            feat.AddRange(featuring);
        }




        /// <summary>
        /// <see cref="ToString"/> de <see cref="Morceau"/> qui affiche le titre suivis de tous les featuring 
        /// </summary>
        /// <returns>Retourne l'auteur, le titre et les artistes en featuring</returns>
        public override string ToString()
        {
            StringBuilder tmp = new($"{Auteur} ");
            if (feat == null)
            {
                return tmp.ToString();
            }
            if (feat.Any())
            {
                tmp.Append("feat. ");
                foreach (Artiste a in feat)
                {
                    tmp.Append($"{a} &");
                }
                tmp.Remove(tmp.Length - 1, 1);
            }
            return tmp.ToString();
        }

        /// <summary>
        /// Methode <see cref="Equals"/> d'un <see cref="Morceau"/>
        /// </summary>
        /// <param name="other">Morceau</param>
        /// <returns>Retourne le résultat des equals entre Titre et Parution</returns>
        public bool Equals(Morceau other)
        {
            return Titre.Equals(other.Titre) && Parution == other.Parution;
        }

        /// <summary>
        /// Methode <see cref="Equals"/> d'un <see cref="Morceau"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne true/false selon les tests d'egalités</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Morceau);
        }

        /// <summary>
        /// Methode <see cref="GetHashCode"/> d'un <see cref="Morceau"/>
        /// </summary>
        /// <returns>Retourne le Hashcode de Titre</returns>
        public override int GetHashCode()
        {
            return Titre.GetHashCode();
        }

        /// <summary>
        /// Methode <see cref="CompareTo"/> d'un <see cref="Morceau"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne le CompareTo de obj casté en Morceau</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Morceau))
            {
                throw new ArgumentException("Ce n'est pas un morceau", nameof(obj));
            }

            Morceau otherMorceau = obj as Morceau;
            return this.CompareTo(otherMorceau);
        }

        /// <summary>
        /// Methode <see cref="CompareTo"/> d'un <see cref="Morceau"/>
        /// </summary>
        /// <param name="other">Morceau</param>
        /// <returns>Retourne le résultat de CompareTo du Titre</returns>
        public int CompareTo(Morceau other)
        {
            return Titre.CompareTo(other.Titre);
        }
    }
}

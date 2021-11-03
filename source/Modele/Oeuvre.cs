using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Modele
{
    /// <summary>
    /// Représent une <see cref="Oeuvre"/>
    /// </summary>
    public class Oeuvre : IEquatable<Oeuvre>, IComparable<Oeuvre>, IComparable
    {
        [BsonId]
        public Guid Id { get; set; }

        /// <summary>
        /// Titre du <see cref="Morceau"/> ou d'un <see cref="Album"/>
        /// </summary>
        public string Titre
        {
            get
            {
                return titre;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Un Morceau doit avoir un titre.");
                }
                else titre = value;
            }
        }
        private string titre;

        /// <summary>
        /// Auteur du <see cref="Morceau"/> ou d'un <see cref="Album"/>
        /// </summary>
        public Artiste Auteur
        {
            get
            {
                return auteur;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("L'auteur d'un morceau ne peut pas être null.");
                }
                else auteur = value;
            }
        }
        private Artiste auteur;




        /// <summary>
        /// date de parution du <see cref="Morceau"/> ou d'un <see cref="Album"/>
        /// </summary>
        public DateTime Parution
        {
            get;
            private set;
        }

        /// <summary>
        /// Image d'une oeuvre
        /// </summary>
        public string Image
        {
            get;
            private set;

        }

        /// <summary>
        /// Constructeur d'<see cref="Oeuvre"/>
        /// </summary>
        /// <param name="titre">string</param>
        /// <param name="auteur">string</param>
        /// <param name="parution">DateTime</param>
        public Oeuvre(string titre, Artiste auteur, DateTime parution, string image)
        {
            Titre = titre;
            Auteur = auteur;
            Parution = parution;
            Image = image;
        }

        /// <summary>
        /// Methode <see cref="Equals"/> d'un <see cref="Album"/>
        /// </summary>
        /// <param name="other">Album</param>
        /// <returns>retourne le resultat des equals de Titre et de l'Auteur</returns>
        public bool Equals(Oeuvre other)
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

            return Equals(obj as Oeuvre);
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
            if (!(obj is Oeuvre))
            {
                throw new ArgumentException("Ce n'est pas un album", nameof(obj));
            }

            Oeuvre otherOeuvre = obj as Oeuvre;
            return this.CompareTo(otherOeuvre);
        }


        /// <summary>
        /// Méthode <see cref="CompareTo"/>  d'un <see cref="Album"/>
        /// </summary>
        /// <param name="other">Album</param>
        /// <returns>Retourne le résultat de CompareTo du Titre</returns>
        public int CompareTo(Oeuvre other)
        {
            return Titre.CompareTo(other.Titre);
        }
    }
}

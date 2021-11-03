using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modele
{
    /// <summary>
    /// Représente un <see cref="Artiste"/>
    /// </summary>
    public class Artiste : IEquatable<Artiste>, IComparable<Artiste>, IComparable
    {
        [BsonId]
        public Guid Id { get; set; }


        /// <summary>
        /// Nom de l'<see cref="Artiste"/>
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
                    throw new ArgumentException("Un artiste doit avoir un nom.");
                }
                else nom = value;
            }
        }
        private string nom;


        /// <summary>
        /// Description de l'<see cref="Artiste"/>
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
                    throw new ArgumentException("Un artiste doit avoir une description.");
                }
                else description = value;
            }
        }
        private string description;


        /// <summary>
        /// Date de naissance de l'<see cref="Artiste"/>
        /// </summary>
        public DateTime DateNaissance
        {
            get;
        }

        /// <summary>
        /// Image d'un artiste
        /// </summary>
        public string Image
        {
            get;
            private set;

        }

        /// <summary>
        /// Liste d'<see cref="Oeuvre"/> de l'<see cref="Artiste"/>
        /// </summary>
        //public ReadOnlyCollection<Oeuvre> ListOeuvres 
        //{ 
        //    get; 
        //    private set; 
        //}
        //List<Oeuvre> lesOeuvres = new();

        public ReadOnlyCollection<Album> ListAlbums
        {
            get;
            private set;
        }
        [BsonIgnoreIfDefault]

        List<Album> lesAlbums = new();

        /// <summary>
        /// Liste des morceau de l'artiste
        /// </summary>
        public ReadOnlyCollection<Morceau> ListMorceaux
        {
            get;
            private set;
        }
        [BsonIgnoreIfDefault]
        List<Morceau> lesMorceaux = new();



        /// <summary>
        /// Ajout d'un IEnumerable d'<see cref="Oeuvre"/> à la page d'un <see cref="Artiste"/>
        /// </summary>
        /// <param name="oeuvres">IEnumerable<Oeuvre></param>
        public void AjouterListOeuvres(IEnumerable<Oeuvre> oeuvres)
        {
            foreach (Oeuvre o in oeuvres)
            {
                if (o is Album)
                {
                    lesAlbums.Add(o as Album);
                }
                else
                {
                    lesMorceaux.Add(o as Morceau);
                }
            }
        }

        /// <summary>
        /// Ajout d'une <see cref="Oeuvre"/> à la page d'un <see cref="Artiste"/>
        /// </summary>
        /// <param name="oeuvre">Oeuvre</param>
        public void AjouterOeuvre(Oeuvre oeuvre)
        {
            if (oeuvre is Album)
            {
                lesAlbums.Add(oeuvre as Album);
            }
            else
            {
                lesMorceaux.Add(oeuvre as Morceau);
            }
        }

        /// <summary>
        /// Suppression d'une <see cref="Oeuvre"/> de la page d'un <see cref="Artiste"/>
        /// </summary>
        /// <param name="oeuvre">Oeuvre</param>
        public void SupprimerOeuvre(Oeuvre oeuvre)
        {
            if (oeuvre is Album)
            {
                lesAlbums.Remove(oeuvre as Album);
            }
            else
            {
                lesMorceaux.Remove(oeuvre as Morceau);
            }
        }

        /// <summary>
        /// Constructeur d'un <see cref="Artiste"/> par défaut
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="description">string</param>
        /// <param name="dateNaissance">DateTime</param>
        public Artiste(string nom, string description, DateTime dateNaissance, string image)
        {
            Nom = nom;
            Description = description;
            DateNaissance = dateNaissance;
            Image = image;
            ListAlbums = new ReadOnlyCollection<Album>(lesAlbums);
            ListMorceaux = new ReadOnlyCollection<Morceau>(lesMorceaux);
        }

        /// <summary>
        /// Constructeur d'un <see cref="Artiste"/> avec un tableau d'<see cref="Oeuvre"/>
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="description">string</param>
        /// <param name="dateNaissance">DateTime</param>
        /// <param name="listOeuvres">IEnumerable<Oeuvre></param>
        public Artiste(string nom, string description, DateTime dateNaissance, string image, IEnumerable<Oeuvre> listOeuvres)
            : this(nom, description, dateNaissance, image)
        {
            AjouterListOeuvres(listOeuvres);
        }

        /// <summary>
        /// Constructeur d'un <see cref="Artiste"/> avec une <see cref="Oeuvre"/>
        /// </summary>
        /// <param name="nom">string</param>
        /// <param name="description">string</param>
        /// <param name="dateNaissance">DateTime</param>
        /// <param name="oeuvre">Oeuvre</param>
        public Artiste(string nom, string description, DateTime dateNaissance, string image, Oeuvre oeuvre)
            : this(nom, description, dateNaissance, image)
        {
            AjouterOeuvre(oeuvre);
        }

        /// <summary>
        /// Redefinition du <see cref="ToString"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <returns>Nom d'un Aritste</returns>
        public override string ToString()
        {
            return $"{Nom}";
        }

        /// <summary>
        /// Methode <see cref="Equals"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <param name="other">Artiste</param>
        /// <returns>retourne le resultat des equals de Nom et DateNaissance</returns>
        public bool Equals(Artiste other)
        {
            return Nom.Equals(other.Nom) && DateNaissance.Equals(other.DateNaissance);
        }

        /// <summary>
        /// Methode <see cref="Equals"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne true/false selon les tests d'egalités</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as Artiste);
        }

        /// <summary> 
        /// Methode <see cref="GetHashCode"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <returns>Retourne le HashCode de Nom</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }


        /// <summary>
        /// Methode <see cref="CompareTo"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>Retourne le CompareTo de obj casté en Artiste</returns>
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Artiste))
            {
                throw new ArgumentException("Ce n'est pas un artiste", nameof(obj));
            }

            Artiste otherArtiste = obj as Artiste;
            return this.CompareTo(otherArtiste);
        }


        /// <summary>
        /// Methode <see cref="CompareTo"/> pour un <see cref="Artiste"/>
        /// </summary>
        /// <param name="other">Artiste</param>
        /// <returns>Retourne le résultat de CompareTo du Nom</returns>
        public int CompareTo(Artiste other)
        {
            return Nom.CompareTo(other.Nom);
        }
    }
}

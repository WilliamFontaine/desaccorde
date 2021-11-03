using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Modele
{
    /// <summary>
    /// <see cref="Manager"/> de l'application
    /// </summary>
    public partial class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// dépendance vers le gestionnaire de la persistance
        /// </summary>
        public IPersistanceManager Persistance
        {
            get;
            private set;
        }

        /// <summary>
        /// Méthode pour charger toutes les données 
        /// </summary>
        public void ChargeDonnees()
        {
            var donnees = Persistance.ChargeDonnees();

            artistes.AddRange(donnees.artistes);

            oeuvres.AddRange(donnees.albums);

            oeuvres.AddRange(donnees.morceaux);

            users.AddRange(donnees.utilisateurs);

            CurrentUser = donnees.currentUser;

            foreach (KeyValuePair<Oeuvre, List<Avis>> d in donnees.avis)
            {
                appreciations.Add(d.Key, d.Value);
            }
        }

        /// <summary>
        /// Méthode pour sauvegarder toutes les données
        /// </summary>
        public void SauvegardeDonnees()
        {
            Persistance.SauvegardeDonnees(Artistes, (IEnumerable<Album>)Albums, (IEnumerable<Morceau>)Morceaux, Utilisateurs, CurrentUser, appreciations);
        }

        /// <summary>
        /// Liste d'<see cref="Utilisateur"/> de l'application
        /// </summary>
        public ReadOnlyCollection<Utilisateur> Utilisateurs
        {
            get;
            private set;
        }
        List<Utilisateur> users = new();

        /// <summary>
        /// <see cref="Utilisateur"/> actuel de l'application
        /// </summary>
        public Utilisateur CurrentUser
        {
            get;
            set;
        }

        /// <summary>
        /// Oeuvre selectionnée de l'application 
        /// </summary>
        public Oeuvre CurrentMorceau
        {
            get => currentMorceau;
            set
            {
                currentMorceau = value;
                OnPropertyChanged();
            }
        }
        private Oeuvre currentMorceau;

        /// <summary>
        /// Oeuvre selectionnée de l'application 
        /// </summary>
        public Oeuvre CurrentAlbum
        {
            get;
            set;
        }

        /// <summary>
        /// Artiste selectionné de l'application
        /// </summary>
        public Artiste CurrentArtiste
        {
            get;
            set;
        }

        /// <summary>
        /// Liste d'<see cref="Oeuvre"/> de l'application
        /// </summary>
        public ReadOnlyCollection<Oeuvre> Oeuvres
        {
            get;
            private set;
        }
        List<Oeuvre> oeuvres = new();

        public IEnumerable<Oeuvre> Albums => Oeuvres.Where(o => o is Album).OrderBy(n => n.Titre);


        public IEnumerable<Oeuvre> Morceaux => Oeuvres.Where(o => o is Morceau).OrderBy(n => n.Titre);


        /// <summary>
        /// Liste d'<see cref="Artiste"/> de l'application
        /// </summary>
        public ReadOnlyCollection<Artiste> Artistes
        {
            get;
            private set;
        }
        List<Artiste> artistes = new();

        /// <summary>
        /// Playlist séléctionnée
        /// </summary>
        public Playlist CurrentPlaylist
        {
            get
            {
                return currentPlaylist;
            }
            set
            {
                if (CurrentPlaylist != value)
                {
                    currentPlaylist = value;
                    OnPropertyChanged(nameof(CurrentPlaylist));
                }
            }
        }
        private Playlist currentPlaylist;

        /// <summary>
        /// Liste de <see cref="Playlist"/> de l'application
        /// </summary>
        public ReadOnlyObservableCollection<Playlist> Playlists
        {
            get;
            private set;
        }
        ObservableCollection<Playlist> playlists = new();

        /// <summary>
        /// Dictionnaire d'appréciations
        /// </summary>
        public ReadOnlyDictionary<Oeuvre, List<Avis>> Appreciations
        {
            get;
            private set;
        }
        Dictionary<Oeuvre, List<Avis>> appreciations = new();

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Texte entré par l'utilisateur
        /// </summary>
        public string Result_Recherche { get; set; }

        /// <summary>
        /// Genre choisi pour rechercher des morceaux
        /// </summary>
        public Genre CurrentGenre { get; set; }

        /// <summary>
        /// Comstructeur du <see cref="Manager"/>
        /// </summary>
        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
            Utilisateurs = new ReadOnlyCollection<Utilisateur>(users);
            Artistes = new ReadOnlyCollection<Artiste>(artistes);
            Oeuvres = new ReadOnlyCollection<Oeuvre>(oeuvres);
            Playlists = new ReadOnlyObservableCollection<Playlist>(playlists);
            Appreciations = new ReadOnlyDictionary<Oeuvre, List<Avis>>(appreciations);
        }
    }
}

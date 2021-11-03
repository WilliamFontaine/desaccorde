using desaccordeVues.UC_windowParts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace desaccordeVues
{
    public class Navigator : INotifyPropertyChanged
    {
        public const string PART_ACCUEIL = "Accueil";
        public const string PART_ALBUM = "AlbumDetaille";
        public const string PART_ALBUMFAV = "AlbumFavoris";
        public const string PART_ARTISTE = "ArtisteDetaille";
        public const string PART_ARTISTEFAV = "ArtistesFavoris";
        public const string PART_MORCEAUFAV = "MorceauxFavoris";
        public const string PART_PLAYLIST = "Playlist";
        public const string PART_RECHERCHE = "Recherche";
        public const string PART_RECHERCHEGENRE = "RechercheGenre";
        public const string PART_AVISALBUM = "AvisAlbum";
        public const string PART_AVISMORCEAU = "AvisMorceau";
        public ReadOnlyDictionary<string, Func<UserControl>> WindowParts { get; private set; }

        Dictionary<string, Func<UserControl>> WindowPart { get; set; } = new()
        {
            [PART_ACCUEIL] = () => new PageAccueilAppli_UC(),
            [PART_ALBUM] = () => new PageAlbumDetaillee_UC(),
            [PART_ALBUMFAV] = () => new PageAlbumsFavoris_UC(),
            [PART_ARTISTE] = () => new PageArtisteDetaillee_UC(),
            [PART_ARTISTEFAV] = () => new PageArtistesFavoris_UC(),
            [PART_MORCEAUFAV] = () => new PageMorceauxFavoris_UC(),
            [PART_PLAYLIST] = () => new PagePlaylistDetaillee_UC(),
            [PART_RECHERCHE] = () => new PageRecherche_UC(),
            [PART_RECHERCHEGENRE] = () => new PageRechercheGenre_UC(),
            [PART_AVISALBUM] = () => new PageAvisAlbum_UC(),
            [PART_AVISMORCEAU] = () => new PageAvisMorceau_UC(),
        };

        public Navigator()
        {
            WindowParts = new ReadOnlyDictionary<string, Func<UserControl>>(WindowPart);
            SelectedUserControlCreator = WindowParts.First();
        }

        public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreator
        {
            get => selectedUserControlCreator;
            set
            {
                //if (selectedUserControlCreator.Equals(value)) return;
                selectedUserControlCreator = value;
                OnPropertyChanged();
            }
        }

        private KeyValuePair<string, Func<UserControl>> selectedUserControlCreator;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void NavigateTo(string windowPartName)
        {
            if (WindowParts.ContainsKey(windowPartName))
            {
                SelectedUserControlCreator = WindowParts.Single(kvp => kvp.Key == windowPartName);
            }
        }
    }
}

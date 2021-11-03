using desaccordeVues.UC_SoundBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace desaccordeVues
{
    public class Navigator_SoundControl : INotifyPropertyChanged
    {
        public const string PART_APP = "Application";
        public const string PART_ALBUM = "Album";
        public const string PART_PLAYLIST = "Playlist";
        public const string PART_FAVORIS = "Favoris";

        public ReadOnlyDictionary<string, Func<UserControl>> WindowParts { get; private set; }

        Dictionary<string, Func<UserControl>> WindowPart { get; set; } = new()
        {
            [PART_APP] = () => new SoundBarApp_UC(),
            [PART_ALBUM] = () => new SoundBarAlbum_UC(),
            [PART_PLAYLIST] = () => new SoundBarPlaylist_UC(),
            [PART_FAVORIS] = () => new SoundBarFavoris_UC(),
        };

        public Navigator_SoundControl()
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

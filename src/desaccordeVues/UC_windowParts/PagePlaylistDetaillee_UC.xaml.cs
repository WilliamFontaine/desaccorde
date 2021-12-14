using desaccordeVues.Windows;
using Modele;
using Mongo;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PagePlaylistDetaillee_UC.xaml
    /// </summary>
    public partial class PagePlaylistDetaillee_UC : UserControl, INotifyPropertyChanged
    {
        public static Navigator Nvr => (App.Current as App).Navigator;

        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;

        public static Manager Mgr => (App.Current as App).LeManager;

        public static Navigator_SoundControl Nvr_Sound => (App.Current as App).Navigator_SoundControl;

        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public static MongoCRUD Mongo => (App.Current as App).db;

        public PagePlaylistDetaillee_UC()
        {
            InitializeComponent();
            Nvr_Sound.NavigateTo(Navigator_SoundControl.PART_PLAYLIST);
            MorceauxTriés = Convert(Mgr.CurrentPlaylist.Morceaux);
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public IEnumerable<Morceau> MorceauxTriés
        {
            get
            {
                return morceauxTriés;
            }
            private set
            {
                morceauxTriés = value;
                OnPropertyChanged();
            }
        }
        private IEnumerable<Morceau> morceauxTriés;

        private static IEnumerable<Morceau> Convert(IEnumerable<Oeuvre> oeuvres)
        {
            List<Morceau> temp = new();
            foreach (Oeuvre o in oeuvres)
            {
                if (o is Morceau) temp.Add(o as Morceau);
            }
            return temp;
        }
        private void TitreSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriTitreAsc(Convert(Mgr.CurrentPlaylist.Morceaux));
        }

        private void AuteurSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriArtisteAsc(Convert(Mgr.CurrentPlaylist.Morceaux));
        }

        private void DateSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriDateAsc(Convert(Mgr.CurrentPlaylist.Morceaux));
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var modifierWindow = new ModifierPlaylist();

            modifierWindow.ShowDialog();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer cette playlist ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                Mgr.CurrentUser.SupprimerPlaylist(Mgr.CurrentPlaylist);
                Mongo.DeletePlaylistUser(Mgr.CurrentUser, Mgr.CurrentPlaylist);
                Nvr.NavigateTo(Navigator.PART_ACCUEIL);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_ONLINE);
            }
        }

        private void SupprimerPlaylistMorceau_Click(object sender, RoutedEventArgs e)
        {
            if (!Mgr.CurrentPlaylist.Morceaux.Contains(Mgr.CurrentMorceau))
            {
                MessageBox.Show("Le morceau n'est pas dans la playlist !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentPlaylist.SupprimerOeuvre(Mgr.CurrentMorceau);
                Mongo.DeleteMorceauPlaylist(Mgr.CurrentUser, Mgr.CurrentPlaylist, Mgr.CurrentMorceau as Morceau);
                MorceauxTriés = Convert(Mgr.CurrentPlaylist.Morceaux);
                Nvr.NavigateTo(Navigator.PART_PLAYLIST);
            }
        }

        private void AjouterFavorisMorceau_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser.Morceaux.Contains(Mgr.CurrentMorceau))
            {
                MessageBox.Show("Morceau deja présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterOeuvre(Mgr.CurrentMorceau);
                Mongo.AddMorceauUser(Mgr.CurrentUser, Mgr.CurrentMorceau as Morceau);
            }
        }

        private void AlbumDetaille_Click(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ALBUM);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentPlaylist.Morceaux.Count == 0)
            {
                return;
            }
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            Mgr.CurrentMorceau = Mgr.CurrentPlaylist.Morceaux[0];
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentPlaylist.Morceaux.Count == 0)
            {
                return;
            }
            Random rdn = new();
            int i = rdn.Next(0, Mgr.CurrentPlaylist.Morceaux.Count);
            Mgr.CurrentMorceau = Mgr.CurrentPlaylist.Morceaux[i];
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }

        private void Double_Click(object sender, MouseButtonEventArgs e)
        {
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }

        private void AvisMorceau_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
        }
    }
}

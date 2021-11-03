using Modele;
using Mongo;
using NAudio.Wave;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PageAccueilAppli_UC.xaml
    /// </summary>
    public partial class PageAccueilAppli_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static Navigator_SoundControl Nvr_Sound => (App.Current as App).Navigator_SoundControl;
        public static IWavePlayer Player => (App.Current as App).waveOutDevice;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageAccueilAppli_UC()
        {
            InitializeComponent();
            Nvr_Sound.NavigateTo(Navigator_SoundControl.PART_APP);
            DataContext = Mgr;
        }

        private void AlbumDetaille_Click(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ALBUM);
        }

        private void AjouterFavorisAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour ajouter un album aux favoris.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Mgr.CurrentUser.Albums.Contains(Mgr.CurrentAlbum))
            {
                MessageBox.Show("Album déjà présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterOeuvre(Mgr.CurrentAlbum);
                Mongo.AddAlbumUser(Mgr.CurrentUser, Mgr.CurrentAlbum as Album);
            }
        }

        private void AjouterFavorisMorceau_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour ajouter un morceau aux favoris.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Mgr.CurrentUser.Morceaux.Contains(Mgr.CurrentMorceau))
            {
                MessageBox.Show("Morceau deja présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterOeuvre(Mgr.CurrentMorceau);
                Mongo.AddMorceauUser(Mgr.CurrentUser, Mgr.CurrentMorceau as Morceau);
            }
        }
        private void MenuItemPlaylistMorceau_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;
            var p = m.Header as string;
            Mgr.CurrentUser.GetPlaylist(p);
            //if(Mgr.CurrentUser.Playlists.Contains)
            if (Mgr.CurrentUser.GetPlaylist(p).Morceaux.Contains(Mgr.CurrentMorceau))
            {
                MessageBox.Show("La playlist contient déjà ce morceau !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.GetPlaylist(p).AjouterOeuvre(Mgr.CurrentMorceau);
                Mongo.AddMorceauPlaylist(Mgr.CurrentUser, Mgr.CurrentUser.GetPlaylist(p), Mgr.CurrentMorceau as Morceau);
            }
        }

        private void AvisMorceau_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
        }

        private void AvisAlbum_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_AVISALBUM);
        }

        private void MorceauDouble_Click(object sender, MouseButtonEventArgs e)
        {
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }
    }
}

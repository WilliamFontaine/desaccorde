using Modele;
using Mongo;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PageRecherche_UC.xaml
    /// </summary>
    public partial class PageRecherche_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;

        public IEnumerable<Morceau> LesMorceaux { get; set; }

        public IEnumerable<Artiste> LesArtistes { get; set; }

        public IEnumerable<Album> LesAlbums { get; set; }

        public static IWavePlayer Player => (App.Current as App).waveOutDevice;
        public PageRecherche_UC()
        {
            InitializeComponent();
            DataContext = this;
            LesMorceaux = Mgr.RechercheMorceau(Mgr.Result_Recherche);
            LesAlbums = Mgr.RechercheAlbum(Mgr.Result_Recherche);
            LesArtistes = Mgr.RechercheArtiste(Mgr.Result_Recherche);
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
                MessageBox.Show("Album déjà présent dans les favoris", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterOeuvre(Mgr.CurrentAlbum);
                Mongo.AddAlbumUser(Mgr.CurrentUser, Mgr.CurrentAlbum as Album);
            }
        }

        private void ArtisteDetaille_Click(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ARTISTE);
        }

        private void AjouterFavorisArtiste_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour ajouter un artiste aux favoris.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Mgr.CurrentUser.Artistes.Contains(Mgr.CurrentArtiste))
            {
                MessageBox.Show("Artiste déjà présent dans les favoris", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterArtiste(Mgr.CurrentArtiste);
                Mongo.AddArtisteUser(Mgr.CurrentUser, Mgr.CurrentArtiste);
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

        private void MorceauDouble_Click(object sender, MouseButtonEventArgs e)
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

        private void AvisAlbum_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_AVISALBUM);
        }
    }
}

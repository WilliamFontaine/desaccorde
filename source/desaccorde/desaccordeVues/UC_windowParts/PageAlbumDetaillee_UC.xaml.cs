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
    /// Logique d'interaction pour PageAlbumDetaillee_UC.xaml
    /// </summary>
    public partial class PageAlbumDetaillee_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;

        public static Navigator_SoundControl Nvr_Sound => (App.Current as App).Navigator_SoundControl;

        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public static MongoCRUD Mongo => (App.Current as App).db;

        public PageAlbumDetaillee_UC()
        {
            InitializeComponent();
            Nvr_Sound.NavigateTo(Navigator_SoundControl.PART_ALBUM);
            DataContext = this;
        }


        private void Ajouter_Click(object sender, RoutedEventArgs e)
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

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock t = sender as TextBlock;
            string nom = t.Text as string;

            Mgr.CurrentArtiste = Mgr.GetArtiste(nom);
            Nvr.NavigateTo(Navigator.PART_ARTISTE);
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

        private void Commentaire_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_AVISALBUM);
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour pouvoir noter un album.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Mgr.Appreciations.ContainsKey(Mgr.CurrentAlbum))
                {
                    List<Avis> avis = new();
                    Mgr.Appreciations.TryGetValue(Mgr.CurrentAlbum, out avis);
                    foreach (Avis a in avis)
                    {
                        if (a.User.Equals(Mgr.CurrentUser))
                        {
                            Mongo.UpdateAvisType(new Avis(null, Mgr.CurrentUser, Modele.Type.Indesirable), Mgr.CurrentAlbum);
                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Indesirable), Mgr.CurrentAlbum);
                Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Indesirable);
            }
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour pouvoir noter un album.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Mgr.Appreciations.ContainsKey(Mgr.CurrentAlbum))
                {
                    List<Avis> avis = new();
                    Mgr.Appreciations.TryGetValue(Mgr.CurrentAlbum, out avis);
                    foreach (Avis a in avis)
                    {
                        if (a.User.Equals(Mgr.CurrentUser))
                        {
                            Mongo.UpdateAvisType(new Avis(null, Mgr.CurrentUser, Modele.Type.Like), Mgr.CurrentAlbum);
                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Like), Mgr.CurrentAlbum);
                Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Like);
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if ((Mgr.CurrentAlbum as Album).Tracklist.Count == 0)
            {
                return;
            }
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist[0];
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

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            if ((Mgr.CurrentAlbum as Album).Tracklist.Count == 0)
            {
                return;
            }
            Random rdn = new();
            int i = rdn.Next(0, (Mgr.CurrentAlbum as Album).Tracklist.Count);
            Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist[i];
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

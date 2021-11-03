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
    /// Logique d'interaction pour PageRechercheGenre_UC.xaml
    /// </summary>
    public partial class PageRechercheGenre_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;
        public IEnumerable<Morceau> LesMorceaux { get; set; }

        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public PageRechercheGenre_UC()
        {
            InitializeComponent();
            DataContext = this;
            LesMorceaux = Mgr.RechercherGenre(Mgr.CurrentGenre.ToString());
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

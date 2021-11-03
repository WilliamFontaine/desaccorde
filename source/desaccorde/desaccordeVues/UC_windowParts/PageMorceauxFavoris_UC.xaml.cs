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
    /// Logique d'interaction pour PageMorceauxFavoris_UC.xaml
    /// </summary>
    public partial class PageMorceauxFavoris_UC : UserControl, INotifyPropertyChanged
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static Navigator_SoundControl Nvr_Sound => (App.Current as App).Navigator_SoundControl;
        public static MongoCRUD Mongo => (App.Current as App).db;
        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public PageMorceauxFavoris_UC()
        {
            InitializeComponent();
            if (Mgr.CurrentUser != null)
            {
                MorceauxTriés = Mgr.CurrentUser.Morceaux;
            }
            Nvr_Sound.NavigateTo(Navigator_SoundControl.PART_FAVORIS);
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void SupprimerFavoris_Click(object sender, RoutedEventArgs e)
        {
            if (!Mgr.CurrentUser.Morceaux.Contains(Mgr.CurrentMorceau))
            {
                MessageBox.Show("Le morceau n'est pas présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.SupprimerOeuvre(Mgr.CurrentMorceau);
                Mongo.DeleteMorceauUser(Mgr.CurrentUser, Mgr.CurrentMorceau as Morceau);
                Nvr.NavigateTo(Navigator.PART_MORCEAUFAV);
            }
        }

        private void TitreSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriTitreAsc(Mgr.CurrentUser.Morceaux);
        }

        private void AuteurSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriArtisteAsc(Mgr.CurrentUser.Morceaux);
        }

        private void DateSort_Click(object sender, RoutedEventArgs e)
        {
            MorceauxTriés = Mgr.TriDateAsc(Mgr.CurrentUser.Morceaux);
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

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser.Morceaux.Count == 0)
            {
                return;
            }
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            Mgr.CurrentMorceau = Mgr.CurrentUser.Morceaux[0];
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
            if (Mgr.CurrentUser.Morceaux.Count == 0)
            {
                return;
            }
            Random rdn = new();
            int i = rdn.Next(0, Mgr.CurrentUser.Morceaux.Count);

            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, Mgr.CurrentUser.Morceaux[i].Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }
    }
}

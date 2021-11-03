using desaccordeVues.Windows;
using Modele;
using Mongo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PageAvisAlbum_UC.xaml
    /// </summary>
    public partial class PageAvisAlbum_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageAvisAlbum_UC()
        {
            InitializeComponent();
            Mgr.Appreciations.TryGetValue(Mgr.CurrentAlbum, out appreciation);
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public List<Avis> Appreciation
        {
            get
            {
                return appreciation;
            }
            set
            {
                appreciation = value;
                OnPropertyChanged();
            }
        }
        private List<Avis> appreciation;

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock t = sender as TextBlock;
            string nom = t.Text as string;

            Mgr.CurrentArtiste = Mgr.GetArtiste(nom);
            Nvr.NavigateTo(Navigator.PART_ARTISTE);
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

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour noter un album.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                            Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Like);
                            Nvr.NavigateTo(Navigator.PART_AVISALBUM);
                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Like), Mgr.CurrentAlbum);
                Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Like);
                Nvr.NavigateTo(Navigator.PART_AVISALBUM);
            }
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour noter un album.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                            Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Indesirable);
                            Nvr.NavigateTo(Navigator.PART_AVISALBUM);
                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Indesirable), Mgr.CurrentAlbum);
                Mgr.Noter(Mgr.CurrentAlbum, Modele.Type.Indesirable);
                Nvr.NavigateTo(Navigator.PART_AVISALBUM);
            }
        }

        private void Album_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ALBUM);
        }

        private void Commentaire_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour commenter un album.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var ajouterWindow = new CommentaireAlbum();
                ajouterWindow.ShowDialog();
            }
        }

        private void SuppriCommentaire_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour supprimer votre commentaire.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Mgr.SupprimerAvisAlbum();
                Nvr.NavigateTo(Navigator.PART_AVISALBUM);
            }
        }
    }
}

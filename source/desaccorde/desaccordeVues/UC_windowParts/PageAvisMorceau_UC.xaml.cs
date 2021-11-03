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
    /// Logique d'interaction pour PageAvisMorceau_UC.xaml
    /// </summary>
    public partial class PageAvisMorceau_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageAvisMorceau_UC()
        {
            InitializeComponent();
            Mgr.Appreciations.TryGetValue(Mgr.CurrentMorceau, out appreciation);
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

        private void MenuItemPlaylist_Click(object sender, RoutedEventArgs e)
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

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour noter un morceau.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Mgr.Appreciations.ContainsKey(Mgr.CurrentMorceau))
                {
                    List<Avis> avis = new();
                    Mgr.Appreciations.TryGetValue(Mgr.CurrentMorceau, out avis);
                    foreach (Avis a in avis)
                    {
                        if (a.User.Equals(Mgr.CurrentUser))
                        {
                            Mongo.UpdateAvisType(new Avis(null, Mgr.CurrentUser, Modele.Type.Like), Mgr.CurrentMorceau);
                            Mgr.Noter(Mgr.CurrentMorceau, Modele.Type.Like);
                            Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);

                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Like), Mgr.CurrentMorceau);
                Mgr.Noter(Mgr.CurrentMorceau, Modele.Type.Like);
                Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
            }
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour noter un morceau.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (Mgr.Appreciations.ContainsKey(Mgr.CurrentMorceau))
                {
                    List<Avis> avis = new();
                    Mgr.Appreciations.TryGetValue(Mgr.CurrentMorceau, out avis);
                    foreach (Avis a in avis)
                    {
                        if (a.User.Equals(Mgr.CurrentUser))
                        {
                            Mongo.UpdateAvisType(new Avis(null, Mgr.CurrentUser, Modele.Type.Indesirable), Mgr.CurrentMorceau);
                            Mgr.Noter(Mgr.CurrentMorceau, Modele.Type.Indesirable);
                            Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
                            return;
                        }
                    }
                }
                Mongo.AddAvis(new Avis(null, Mgr.CurrentUser, Modele.Type.Indesirable), Mgr.CurrentMorceau);
                Mgr.Noter(Mgr.CurrentMorceau, Modele.Type.Indesirable);
                Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
            }
        }

        private void Commentaire_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour commenter un morceau.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var ajouterWindow = new CommentaireMorceau();
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
                Mgr.SupprimerAvisMorceau();
                Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
            }
        }
    }
}
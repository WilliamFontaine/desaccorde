using Modele;
using Mongo;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PageArtisteDetaillee_UC.xaml
    /// </summary>
    public partial class PageArtisteDetaillee_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageArtisteDetaillee_UC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Album_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                MessageBox.Show("Veuillez vous connecter pour ajouter un artiste aux favoris.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Mgr.CurrentUser.Artistes.Contains(Mgr.CurrentArtiste))
            {
                MessageBox.Show("Artiste déjà présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.AjouterArtiste(Mgr.CurrentArtiste);
                Mongo.AddArtisteUser(Mgr.CurrentUser, Mgr.CurrentArtiste);
            }
        }
    }
}

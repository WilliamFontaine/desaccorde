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
    /// Logique d'interaction pour PageAlbumsFavoris_UC.xaml
    /// </summary>
    public partial class PageAlbumsFavoris_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageAlbumsFavoris_UC()
        {
            InitializeComponent();
            DataContext = Mgr;
        }

        private void SupprimerFavoris_Click(object sender, RoutedEventArgs e)
        {
            if (!Mgr.CurrentUser.Albums.Contains(Mgr.CurrentAlbum))
            {
                MessageBox.Show("L'Album n'est pas présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.SupprimerOeuvre(Mgr.CurrentAlbum);
                Mongo.DeleteAlbumUser(Mgr.CurrentUser, Mgr.CurrentAlbum as Album);
                Nvr.NavigateTo(Navigator.PART_ALBUMFAV);
            }
        }

        private void AlbumDetaille_Click(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ALBUM);
        }
    }
}

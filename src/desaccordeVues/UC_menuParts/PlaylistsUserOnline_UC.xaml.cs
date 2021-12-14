using Modele;
using Mongo;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_menuParts
{
    /// <summary>
    /// Logique d'interaction pour PlaylistsUserOnline_UC.xaml
    /// </summary>
    public partial class PlaylistsUserOnline_UC : UserControl
    {
        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PlaylistsUserOnline_UC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Playlist_Click(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_PLAYLIST);
        }

        private void SupprimerPlaylist_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer cette playlist ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                Mgr.CurrentUser.SupprimerPlaylist(Mgr.CurrentPlaylist);
                Mongo.DeletePlaylistUser(Mgr.CurrentUser, Mgr.CurrentPlaylist);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_ONLINE);
                Nvr.NavigateTo(Navigator.PART_ACCUEIL);
            }
        }
    }
}

using Modele;
using Mongo;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_windowParts
{
    /// <summary>
    /// Logique d'interaction pour PageArtistesFavoris_UC.xaml
    /// </summary>
    public partial class PageArtistesFavoris_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public PageArtistesFavoris_UC()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void Artiste_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ARTISTE);
        }

        private void SupprimerFavoris_Click(object sender, RoutedEventArgs e)
        {
            if (!Mgr.CurrentUser.Artistes.Contains(Mgr.CurrentArtiste))
            {
                MessageBox.Show("L'artiste n'est pas présent dans les favoris !", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.CurrentUser.SupprimerArtiste(Mgr.CurrentArtiste);
                Mongo.DeleteArtisteUser(Mgr.CurrentUser, Mgr.CurrentArtiste);
                Nvr.NavigateTo(Navigator.PART_ARTISTEFAV);
            }
        }
    }
}

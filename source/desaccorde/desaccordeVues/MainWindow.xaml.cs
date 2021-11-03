using desaccordeVues.Windows;
using MahApps.Metro.Controls;
using Modele;
using NAudio.Wave;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static Navigator Nvr => (App.Current as App).Navigator;

        public static Navigator_Bandeau Nvr_Bandeau => (App.Current as App).Navigator_Bandeau;

        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;

        public static Navigator_SoundControl Nvr_Sound => (App.Current as App).Navigator_SoundControl;

        public static Manager Mgr => (App.Current as App).LeManager;

        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            if (Mgr.CurrentUser == null)
            {
                Nvr_Bandeau.NavigateTo(Navigator_Bandeau.PART_CONNEXION);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_OFFLINE);
            }
            else
            {
                Nvr_Bandeau.NavigateTo(Navigator_Bandeau.PART_UTILISATEUR);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_ONLINE);
            }
        }

        private void Acceuil_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ACCUEIL);
        }

        private void Favoris_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_MORCEAUFAV);
        }

        private void Artiste_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ARTISTEFAV);
        }

        private void Album_Click(object sender, RoutedEventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_ALBUMFAV);
        }

        private void AjouterPlaylist_Click(object sender, RoutedEventArgs e)
        {
            var ajouterWindow = new AjouterPlaylist();

            ajouterWindow.ShowDialog();
        }

        private void Rechercher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Mgr.Result_Recherche = (sender as TextBox).Text;
                Nvr.NavigateTo(Navigator.PART_RECHERCHE);
            }
        }

        private void Slider_Value(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Player.Volume = (float)e.NewValue;
        }
    }
}

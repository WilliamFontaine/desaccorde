using desaccordeVues.converters;
using MahApps.Metro.Controls;
using Modele;
using Mongo;
using System.IO;
using System.Linq;
using System.Windows;

namespace desaccordeVues.Windows
{
    /// <summary>
    /// Logique d'interaction pour AjouterPlaylist.xaml
    /// </summary>
    public partial class AjouterPlaylist : MetroWindow
    {
        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;

        public static Manager Mgr => (App.Current as App).LeManager;

        public static MongoCRUD Mongo => (App.Current as App).db;
        public string Titre { get; set; }

        public string Desc { get; set; }

        public string Image { get; set; }

        public AjouterPlaylist()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentUser == null)
            {
                Close();
                MessageBox.Show("Veuillez vous connecter pour créer une playlist.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Mgr.CurrentUser.Playlists.Any(p => p.Titre.Equals(Titre)))
            {
                Close();
                MessageBox.Show("Playlist deja existante avec ce titre !\nChoisissez-en un nouveau.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (Titre == null)
            {
                Close();
                MessageBox.Show("La playlist doit avoir un Titre !\nChoisissez-en un.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Mgr.CurrentUser.AjouterPlaylist(Titre, Desc, Image);
                Mongo.AddPlaylistUser(Mgr.CurrentUser, Mgr.CurrentUser.GetPlaylist(Titre));
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_ONLINE);
                Close();
            }
        }

        private void Parcourir_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new();
            dlg.InitialDirectory = "C:";
            dlg.FileName = "Images"; // Default file name
            dlg.DefaultExt = ".jpg | .png | .gif"; // Default file extension
            dlg.Filter = "All images files (.jpg, .png, .gif)|*.jpg;*.png;*.gif|JPG files (.jpg)|*.jpg|PNG files (.png)|*.png|GIF files (.gif)|*.gif"; // Filter files by extension 

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                FileInfo fi = new(dlg.FileName);
                string filename = fi.Name;
                int i = 0;
                while (File.Exists(Path.Combine(String2ImageConverterUtilisateur.ImagesPath, filename)))
                {
                    filename = $"{fi.Name.Remove(fi.Name.LastIndexOf('.'))}_{i}.{fi.Extension}";
                }
                File.Copy(dlg.FileName, Path.Combine(String2ImageConverterUtilisateur.ImagesPath, filename));
                Image = filename;
            }
        }
    }
}

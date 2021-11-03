using desaccordeVues.converters;
using MahApps.Metro.Controls;
using Modele;
using Mongo;
using System;
using System.IO;
using System.Windows;

namespace desaccordeVues.Windows
{
    /// <summary>
    /// Logique d'interaction pour ModifierPlaylist.xaml
    /// </summary>
    public partial class ModifierPlaylist : MetroWindow
    {
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;


        public Playlist Tracklist { get; set; }

        public ModifierPlaylist()
        {
            InitializeComponent();
            var p = Mgr.CurrentPlaylist;
            Tracklist = new Playlist(p.Titre, p.Description, p.Image, p.Morceaux, p.Albums);
            DataContext = Tracklist;
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mgr.ModifierPlaylist(Mgr.CurrentPlaylist, Tracklist);
                Mongo.UpdatePlaylist(Mgr.CurrentUser, Mgr.CurrentPlaylist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Choisissez-en un nouveau", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
                Tracklist.Image = filename;
            }

        }
    }
}

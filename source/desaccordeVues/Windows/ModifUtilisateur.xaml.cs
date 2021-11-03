using desaccordeVues.converters;
using MahApps.Metro.Controls;
using Modele;
using Mongo;
using NAudio.Wave;
using System;
using System.IO;
using System.Windows;

namespace desaccordeVues.Windows
{
    /// <summary>
    /// Logique d'interaction pour ModifUtilisateur.xaml
    /// </summary>
    public partial class ModifUtilisateur : MetroWindow
    {
        public static Navigator_Bandeau Nvr_bandeau => (App.Current as App).Navigator_Bandeau;
        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static IWavePlayer Player => (App.Current as App).waveOutDevice;
        public static MongoCRUD Mongo => (App.Current as App).db;

        public Utilisateur Us { get; set; }

        public ModifUtilisateur()
        {
            InitializeComponent();
            var p = Mgr.CurrentUser;
            Us = new Utilisateur(p.Nom, p.Prenom, p.Pseudo, p.DateNaissance, p.Email, p.MotDePasse, p.Image);
            DataContext = Us;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Us.Pseudo) || String.IsNullOrWhiteSpace(Us.MotDePasse))
            {
                MessageBox.Show("Les champs suivants sont obligatoires:\nPseudo, mot de passe.", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Mgr.ModifierUtilisateur(Mgr.CurrentUser, Us);
                Mongo.UpdateUser(Us);
                Nvr_bandeau.NavigateTo(Navigator_Bandeau.PART_UTILISATEUR);
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
                Us.Image = filename;
            }
        }

        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            Mongo.Delete("CurrentUser", Mgr.CurrentUser);
            Mgr.SeDeconnecter();
            Nvr_bandeau.NavigateTo(Navigator_Bandeau.PART_CONNEXION);
            Nvr_Menu.NavigateTo(Navigator_Menu.PART_OFFLINE);
            Close();
            Player.Stop();
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("Voulez-vous vraiment supprimer ce compte ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                Mongo.Delete("Users", Mgr.CurrentUser);
                Mgr.SupprimerUtilisateur(Mgr.CurrentUser);
                Mgr.CurrentUser = null;
                Close();
                Nvr_bandeau.NavigateTo(Navigator_Bandeau.PART_CONNEXION);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_OFFLINE);
            }
        }
    }
}

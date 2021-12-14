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
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : MetroWindow
    {
        public static Navigator_Menu Nvr_Menu => (App.Current as App).Navigator_Menu;
        public static Navigator_Bandeau Nvr_bandeau => (App.Current as App).Navigator_Bandeau;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pseudo { get; set; }
        public string Naissance { get; set; }
        public string Email { get; set; }
        public string Mdp { get; set; }
        public string Image { get; set; }
        public string ConnectMdp { get; set; }
        public string ConnectEmail { get; set; }

        public Connexion()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.SeConnecter(ConnectEmail, ConnectMdp))
            {
                Nvr_bandeau.NavigateTo(Navigator_Bandeau.PART_UTILISATEUR);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_ONLINE);
                Close();
                MessageBox.Show("Connexion réussie!", "Bienvenue", MessageBoxButton.OK, MessageBoxImage.Information);
                Mongo.InsertOne("CurrentUser", Mgr.CurrentUser);
            }
            else
            {
                MessageBox.Show("Identifiants Incorrects !", "Réessayez", MessageBoxButton.OK, MessageBoxImage.Error);
                Nvr_bandeau.NavigateTo(Navigator_Bandeau.PART_CONNEXION);
                Nvr_Menu.NavigateTo(Navigator_Menu.PART_OFFLINE);
                return;
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

        private void Inscription_Click(object sender, RoutedEventArgs e)
        {
            if (Naissance == null)
            {
                MessageBox.Show("Veuillez saisir votre date de naissance !", "erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DateTime Date;

            try
            {
                Date = Convert.ToDateTime(Naissance);
            }
            catch
            {
                MessageBox.Show("Ecriture de la date de naissance non valide.", "erreur !", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Date = Convert.ToDateTime(Naissance);
            if (Nom == null || Prenom == null || Pseudo == null || Email == null || Mdp == null)
            {
                MessageBox.Show("Les champs suivants ne peuvent pas être vides:\nNom, Prenom, Pseudo, Email, Mot de passe.", "erreur !", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else if (Mgr.AjouterUtilisateur(Nom, Prenom, Pseudo, Date, Email, Mdp, Image))
            {
                MessageBox.Show("Inscription réussie !", "Inscription réussie !", MessageBoxButton.OK, MessageBoxImage.Information);
                Mongo.InsertOne("Users", new Utilisateur(Nom, Prenom, Pseudo, Date, Email, Mdp, Image));
            }
            else
            {
                MessageBox.Show("Cet utilisateur existe déjà, veillez essayer avec des coordonnées différentes !", "Compte deja existant", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

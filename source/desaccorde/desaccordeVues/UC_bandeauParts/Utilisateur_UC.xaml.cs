using desaccordeVues.Windows;
using Modele;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace desaccordeVues.UC_bandeauParts
{
    /// <summary>
    /// Logique d'interaction pour Utilisateur_UC.xaml
    /// </summary>
    public partial class Utilisateur_UC : UserControl
    {
        public static Navigator Nvr => (App.Current as App).Navigator;

        public static Manager Mgr => (App.Current as App).LeManager;
        public Utilisateur_UC()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Rechercher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Mgr.Result_Recherche = (sender as TextBox).Text;
                Nvr.NavigateTo(Navigator.PART_RECHERCHE);
            }
        }

        private void Genre_DropDownClosed(object sender, EventArgs e)
        {
            Nvr.NavigateTo(Navigator.PART_RECHERCHEGENRE);
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            var ajouterWindow = new ModifUtilisateur();

            ajouterWindow.ShowDialog();
        }
    }
}

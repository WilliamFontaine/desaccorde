using MahApps.Metro.Controls;
using Modele;
using Mongo;
using System.Collections.Generic;
using System.Windows;

namespace desaccordeVues.Windows
{
    /// <summary>
    /// Logique d'interaction pour CommentaireMorceau.xaml
    /// </summary>
    public partial class CommentaireMorceau : MetroWindow
    {
        public static Navigator Nvr => (App.Current as App).Navigator;
        public static Manager Mgr => (App.Current as App).LeManager;
        public static MongoCRUD Mongo => (App.Current as App).db;

        public string Comment { get; set; }
        public CommentaireMorceau()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Commenter_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.Appreciations.ContainsKey(Mgr.CurrentMorceau))
            {
                List<Avis> avis = new();
                Mgr.Appreciations.TryGetValue(Mgr.CurrentMorceau, out avis);
                foreach (Avis a in avis)
                {
                    if (a.User.Equals(Mgr.CurrentUser))
                    {
                        Mongo.UpdateAvisCommentaire(new Avis(Comment, Mgr.CurrentUser, Modele.Type.Defaut), Mgr.CurrentMorceau);
                        Mgr.Commenter(Mgr.CurrentMorceau, Comment);
                        Close();
                        Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
                        return;
                    }
                }
            }
            Mongo.AddAvis(new Avis(Comment, Mgr.CurrentUser, Modele.Type.Defaut), Mgr.CurrentMorceau);
            Mgr.Commenter(Mgr.CurrentMorceau, Comment);
            Close();
            Nvr.NavigateTo(Navigator.PART_AVISMORCEAU);
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

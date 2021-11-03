using Modele;
using NAudio.Wave;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace desaccordeVues.UC_SoundBar
{
    /// <summary>
    /// Logique d'interaction pour SoundBarAlbum_UC.xaml
    /// </summary>
    public partial class SoundBarAlbum_UC : UserControl
    {
        public static Manager Mgr => (App.Current as App).LeManager;
        public static IWavePlayer Player => (App.Current as App).waveOutDevice;

        public SoundBarAlbum_UC()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist[0];
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void Suivant_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentMorceau == null)
            {
                return;
            }
            else if (Mgr.CurrentMorceau.Equals((Mgr.CurrentAlbum as Album).Tracklist.Last()))
            {
                Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist.First();
            }
            else
            {
                int pos = (Mgr.CurrentAlbum as Album).Tracklist.ToList().IndexOf(Mgr.CurrentMorceau);
                Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist.ToList()[pos + 1];
            }
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }

        private void Precedent_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentMorceau == null)
            {
                return;
            }
            else if (Mgr.CurrentMorceau.Equals((Mgr.CurrentAlbum as Album).Tracklist.First()))
            {
                Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist.Last();
            }
            else
            {
                int pos = (Mgr.CurrentAlbum as Album).Tracklist.ToList().IndexOf(Mgr.CurrentMorceau);
                Mgr.CurrentMorceau = (Mgr.CurrentAlbum as Album).Tracklist.ToList()[pos - 1];
            }
            Player.Stop();
            string p = Directory.GetCurrentDirectory();
            string pa = p + "\\audio\\";
            AudioFileReader audioFileReader = new(Path.Combine(pa, (Mgr.CurrentMorceau as Morceau).Audio));
            Player.Init(audioFileReader);
            Player.Play();
        }
    }
}

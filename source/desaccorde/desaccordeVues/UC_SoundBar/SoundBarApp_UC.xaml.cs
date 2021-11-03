using Modele;
using NAudio.Wave;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace desaccordeVues.UC_SoundBar
{
    /// <summary>
    /// Logique d'interaction pour SoundBarApp_UC.xaml
    /// </summary>
    public partial class SoundBarApp_UC : UserControl
    {
        public static Manager Mgr => (App.Current as App).LeManager;
        public static IWavePlayer Player => (App.Current as App).waveOutDevice;
        public SoundBarApp_UC()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (Mgr.CurrentMorceau == null)
            {
                return;
            }
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
            else if (Mgr.CurrentMorceau.Equals(Mgr.Morceaux.Last()))
            {
                Mgr.CurrentMorceau = Mgr.Morceaux.First();
            }
            else
            {
                int pos = Mgr.Morceaux.ToList().IndexOf(Mgr.CurrentMorceau);
                Mgr.CurrentMorceau = Mgr.Morceaux.ToList()[pos + 1];
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
            else if (Mgr.CurrentMorceau.Equals(Mgr.Morceaux.First()))
            {
                Mgr.CurrentMorceau = Mgr.Morceaux.Last();
            }
            else
            {
                int pos = Mgr.Morceaux.ToList().IndexOf(Mgr.CurrentMorceau);
                Mgr.CurrentMorceau = Mgr.Morceaux.ToList()[pos - 1];
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

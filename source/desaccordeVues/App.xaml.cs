using Modele;
using Mongo;
using NAudio.Wave;
using System.Windows;

namespace desaccordeVues
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager LeManager { get; private set; } = new Manager(new Mongo.MongoDB());

        public Navigator Navigator { get; private set; } = new Navigator();

        public Navigator_Bandeau Navigator_Bandeau { get; private set; } = new Navigator_Bandeau();

        public Navigator_Menu Navigator_Menu { get; private set; } = new Navigator_Menu();

        public Navigator_SoundControl Navigator_SoundControl { get; private set; } = new Navigator_SoundControl();

        public IWavePlayer waveOutDevice = new WaveOut();

        public MongoCRUD db = new();
        public App()
        {
            LeManager.ChargeDonnees();
        }
    }
}

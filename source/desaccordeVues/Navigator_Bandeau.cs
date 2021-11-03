using desaccordeVues.UC_bandeauParts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace desaccordeVues
{
    public class Navigator_Bandeau : INotifyPropertyChanged
    {

        public const string PART_CONNEXION = "Connexion";
        public const string PART_UTILISATEUR = "Utilisateur";

        public ReadOnlyDictionary<string, Func<UserControl>> WindowParts { get; private set; }

        Dictionary<string, Func<UserControl>> WindowPart { get; set; } = new()
        {
            [PART_CONNEXION] = () => new Connexion_UC(),
            [PART_UTILISATEUR] = () => new Utilisateur_UC(),

        };

        public Navigator_Bandeau()
        {
            WindowParts = new ReadOnlyDictionary<string, Func<UserControl>>(WindowPart);
            SelectedUserControlCreator = WindowParts.First();

        }

        public KeyValuePair<string, Func<UserControl>> SelectedUserControlCreator
        {
            get => selectedUserControlCreator;
            set
            {
                //if (selectedUserControlCreator.Equals(value)) return;
                selectedUserControlCreator = value;
                OnPropertyChanged();
            }
        }

        private KeyValuePair<string, Func<UserControl>> selectedUserControlCreator;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void NavigateTo(string windowPartName)
        {
            if (WindowParts.ContainsKey(windowPartName))
            {
                SelectedUserControlCreator = WindowParts.Single(kvp => kvp.Key == windowPartName);
            }
        }
    }
}

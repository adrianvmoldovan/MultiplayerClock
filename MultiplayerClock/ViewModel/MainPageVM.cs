using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplayerClock.Model;

namespace MultiplayerClock.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private List<Player> _players = new List<Player>
        {
            new Player("Adi", Colors.Blue),
            new Player("Cami", Colors.Red),
            new Player("Andi", Colors.Green),
            new Player("Emi", Colors.Violet),
        };
        private GameType _selectedGameType;
        private List<GameType> _availableGameTypes;
        private bool _useSameTime;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Player> Players { get; set; }

        public MainPageVM(int numberOfPlayers)
        {
            Players = new ObservableCollection<Player>();
            _players.ForEach(p => { if (Players.Count < numberOfPlayers) Players.Add(p); });

            _selectedGameType = GameType.Classic;
            _availableGameTypes = new List<GameType> { GameType.Classic, GameType.SuddenDeath };
            _useSameTime = true;
        }

        public GameType SelectedGameType
        {
            get { return _selectedGameType; }
            set
            {
                _selectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public List<GameType> AvailableGameTypes
        {
            get { return _availableGameTypes; }
            set
            {
                _availableGameTypes = value;
                OnPropertyChanged(nameof(AvailableGameTypes));
            }
        }

        public bool UseSameTime
        {
            get { return _useSameTime; }
            set
            {
                _useSameTime = value;
                OnPropertyChanged(nameof(UseSameTime));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

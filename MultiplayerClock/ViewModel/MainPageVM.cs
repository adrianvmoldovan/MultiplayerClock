using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MultiplayerClock.Model;

namespace MultiplayerClock.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private List<Player> _players = new List<Player>
        {
            new Player("Adi" , Colors.Blue  ),
            new Player("Cami", Colors.Red   ),
            new Player("Andi", Colors.Green ),
            new Player("Emi" , Colors.Violet),
        };

        private GameType       _selectedGameType  ;
        private List<GameType> _availableGameTypes;
        private bool           _useSameTime       ;
        private string         _newPlayerName     ;
        private Color          _newPlayerColor    ;
        private Color          _defaultColor = Color.FromArgb("512BD4");

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Player> Players { get; set; }

        public MainPageVM()
        {
            Players = new ObservableCollection<Player>();
            _players.ForEach(p => Players.Add(p));

            _selectedGameType   = GameType.Classic;
            _availableGameTypes = new List<GameType> { GameType.Classic, GameType.SuddenDeath };
            _useSameTime        = true;
            AddPlayerCommand    = new Command(AddPlayer);
            DeletePlayerCommand = new Command<Player>(DeletePlayer);
            _newPlayerName      = "Player name";
            _newPlayerColor     = _defaultColor;
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand DeletePlayerCommand { get; private set; }

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

        public string NewPlayerName
        {
            get { return _newPlayerName; }
            set
            {
                _newPlayerName = value;
                OnPropertyChanged(nameof(NewPlayerName));
            }
        }

        public Color NewPlayerColor
        {
            get { return _newPlayerColor; }
            set
            {
                _newPlayerColor = value;
                OnPropertyChanged(nameof(NewPlayerColor));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPlayer()
        {
            if (NewPlayerName != string.Empty && Players.All(p => p.Name != NewPlayerName) && Players.Count < 8)
            {
                Players.Add(new Player(NewPlayerName, NewPlayerColor));
            }
        }

        private void DeletePlayer(Player deletedPlayer)
        {
            //var deletedPlayer = Players.First(p => p.Name == playerName);
            Players.Remove(deletedPlayer);
        }
    }
}

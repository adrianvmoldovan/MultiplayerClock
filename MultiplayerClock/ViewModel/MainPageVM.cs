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
        private List<Player> _Players = new List<Player>
        {
            new Player("Adi" , Colors.Blue  ),
            new Player("Cami", Colors.Red   ),
            new Player("Andi", Colors.Green ),
            new Player("Emi" , Colors.Violet),
        };

        private GameType       _SelectedGameType  ;
        private List<GameType> _AvailableGameTypes;
        private bool           _UseSameTime       ;
        private string         _NewPlayerName     ;
        private Color          _NewPlayerColor    ;
        private Color          _DefaultColor = Color.FromArgb("512BD4");

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Player> Players { get; set; }

        public MainPageVM()
        {
            Players = new ObservableCollection<Player>();
            _Players.ForEach(p => Players.Add(p));

            _SelectedGameType   = GameType.Classic;
            _AvailableGameTypes = new List<GameType> { GameType.Classic, GameType.SuddenDeath };
            _UseSameTime        = true;
            _NewPlayerName      = "Player name";
            _NewPlayerColor     = _DefaultColor;

            AddPlayerCommand    = new Command(AddPlayer);
            DeletePlayerCommand = new Command<Player>(DeletePlayer);
            StartGameCommand    = new Command(StartGame);
        }

        public ICommand AddPlayerCommand    { get; private set; }
        public ICommand DeletePlayerCommand { get; private set; }
        public ICommand StartGameCommand    { get; private set; }

        public GameType SelectedGameType
        {
            get { return _SelectedGameType; }
            set
            {
                _SelectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public List<GameType> AvailableGameTypes
        {
            get { return _AvailableGameTypes; }
            set
            {
                _AvailableGameTypes = value;
                OnPropertyChanged(nameof(AvailableGameTypes));
            }
        }

        public bool UseSameTime
        {
            get { return _UseSameTime; }
            set
            {
                _UseSameTime = value;
                OnPropertyChanged(nameof(UseSameTime));
            }
        }

        public string NewPlayerName
        {
            get { return _NewPlayerName; }
            set
            {
                _NewPlayerName = value;
                OnPropertyChanged(nameof(NewPlayerName));
            }
        }

        public Color NewPlayerColor
        {
            get { return _NewPlayerColor; }
            set
            {
                _NewPlayerColor = value;
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

        private void StartGame()
        {
            Shell.Current.GoToAsync(nameof(GamePage));
        }
    }
}

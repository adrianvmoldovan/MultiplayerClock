using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel.Services;

namespace MultiplayerClock.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private List<string> _PlayerNames = new List<string>
        {
            "Adi" ,
            "Cami",
            "Andi",
            "Emi" ,
        };

        private GameType       _SelectedGameType  ;
        private List<GameType> _AvailableGameTypes;
        private bool           _UseSameTime       ;
        private string         _NewPlayerName     ;
        private PossibleColor  _NewPlayerColor    ;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<PlayerVM> PlayerVMs { get; set; }

        public MainPageVM(IServiceProvider serviceProvider)
        {
            var context      = ServiceLocator<Context>.Instance;
            var colorManeger = context.ColorsManager;
            PlayerVMs = new ObservableCollection<PlayerVM>();

            int index = 0;
            colorManeger.ReservePossibleColors(4).ForEach(pc =>
            {
                PlayerVMs.Add(new PlayerVM(new Player(_PlayerNames[index++], pc)));
            });

            _SelectedGameType   = GameType.Classic;
            _AvailableGameTypes = new List<GameType> { GameType.Classic, GameType.SuddenDeath };
            _UseSameTime        = true;
            _NewPlayerName      = "Player name";
            _NewPlayerColor     = colorManeger.ReservePossibleColors(1).First();

            AddPlayerCommand    = new Command(AddPlayer);
            DeletePlayerCommand = new Command<PlayerVM>(DeletePlayer);
            SelectColorCommand  = new Command<PlayerVM>(SelectColor);
            StartGameCommand    = new Command(StartGame);
        }

        public ICommand AddPlayerCommand    { get; private set; }
        public ICommand DeletePlayerCommand { get; private set; }
        public ICommand SelectColorCommand  { get; private set; }
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

        public PossibleColor NewPlayerColor
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
            if (NewPlayerName != string.Empty && PlayerVMs.All(p => p.Player.Name != NewPlayerName) && PlayerVMs.Count < 8)
            {
                PlayerVMs.Add(new PlayerVM(new Player(NewPlayerName, NewPlayerColor)));
            }
        }

        private void DeletePlayer(PlayerVM deletedPlayerVM)
        {
            PlayerVMs.Remove(deletedPlayerVM);
        }

        private void SelectColor(PlayerVM playerVM)
        {
            var parameters = new Dictionary<string, object>()
            {
                {"Player", playerVM.Player}
            };

            Shell.Current.GoToAsync(nameof(PickColorPage), parameters);
        }

        private void StartGame()
        {
            Shell.Current.GoToAsync(nameof(GamePage));
        }
    }
}

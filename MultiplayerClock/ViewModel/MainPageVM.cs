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
using MultiplayerClock.Model.Enums;
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

        private List<GameType>  _AvailableGameTypes ;
        private List<Direction> _AvailableDirections;
        private string          _NewPlayerName      ;
        private PossibleColor   _NewPlayerColor     ;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<PlayerVM> PlayerVMs => ServiceLocator<Context>.Instance.PlayerVMs;

        public MainPageVM(IServiceProvider serviceProvider)
        {
            var context      = ServiceLocator<Context>.Instance;
            var colorManager = context.ColorsManager;

            int index = 0;
            colorManager.ReservePossibleColors(4).ForEach(pc =>
            {
                PlayerVMs.Add(new PlayerVM(new Player(_PlayerNames[index++], pc)));
            });

            _AvailableGameTypes  = new List<GameType> { GameType.Classic, GameType.SuddenDeath };
            _AvailableDirections = new List<Direction> { Direction.Clockwise, Direction.CounterClockwise };
            _NewPlayerName       = "Player name";
            _NewPlayerColor      = colorManager.ReservePossibleColors(1).First();

            AddPlayerCommand    = new Command(AddPlayer);
            DeletePlayerCommand = new Command<PlayerVM>(DeletePlayer);
            SelectColorCommand  = new Command<PlayerVM>(SelectColor);
            StartGameCommand    = new Command(StartGame);

            ServiceLocator<Context>.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SelectedGameType))
                    OnPropertyChanged(nameof(SelectedGameType));

                if (e.PropertyName == nameof(Direction))
                    OnPropertyChanged(nameof(Direction));

                if (e.PropertyName == nameof(UseSameTime))
                    OnPropertyChanged(nameof(UseSameTime));
            };
        }

        public ICommand AddPlayerCommand    { get; private set; }
        public ICommand DeletePlayerCommand { get; private set; }
        public ICommand SelectColorCommand  { get; private set; }
        public ICommand StartGameCommand    { get; private set; }

        public GameType SelectedGameType
        {
            get => ServiceLocator<Context>.Instance.SelectedGameType;
            set
            {
                ServiceLocator<Context>.Instance.SelectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public Direction SelectedDirection
        {
            get => ServiceLocator<Context>.Instance.SelectedDirection;
            set
            {
                ServiceLocator<Context>.Instance.SelectedDirection = value;
                OnPropertyChanged(nameof(SelectedDirection));
            }
        }

        public bool UseSameTime
        {
            get { return ServiceLocator<Context>.Instance.UseSameTime; }
            set
            {
                ServiceLocator<Context>.Instance.UseSameTime = value;
                OnPropertyChanged(nameof(UseSameTime));
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

        public List<Direction> AvailableDirections
        {
            get { return _AvailableDirections; }
            set
            {
                _AvailableDirections = value;
                OnPropertyChanged(nameof(AvailableDirections));
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

using MultiplayerClock.Model;
using MultiplayerClock.Model.Enums;
using MultiplayerClock.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiplayerClock.ViewModel
{
    public class GameVM : INotifyPropertyChanged
    {
        public GameVM()
        {
            _CurrentPlayerIndex = 0;
            PlayerVMs[_CurrentPlayerIndex].StartTimer();
            _currentPlayerVM = PlayerVMs[_CurrentPlayerIndex];
            NextPlayerCommand = new Command(NextPlayer);
            PreviousPlayerCommand = new Command(PreviousPlayer);
            var context = ServiceLocator<Context>.Instance;
            context.IsPaused = false;
            context.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(context.GameStarted))
                {
                    if (context.GameStarted)
                        Play();
                    else
                        StopGame();
                }
            };
        }

        public ICommand NextPlayerCommand { get; private set; }
        public ICommand PreviousPlayerCommand { get; private set; }
        private int _CurrentPlayerIndex;
        public ObservableCollection<PlayerVM> PlayerVMs => ServiceLocator<Context>.Instance.PlayerVMs;

        private PlayerVM _currentPlayerVM;
        public PlayerVM CurrentPlayerVM
        {
            get => _currentPlayerVM;
            set
            {
                if (_currentPlayerVM != value)
                {
                    _currentPlayerVM = value;
                    OnPropertyChanged(nameof(CurrentPlayerVM));
                }
            }
        }

        private void NextPlayer()
        {
            int playerCount = PlayerVMs.Count;
            Direction direction = ServiceLocator<Context>.Instance.SelectedDirection;
            int? nextPlayerIndex;
            if (direction == Direction.CounterClockwise)
            {
                nextPlayerIndex = (_CurrentPlayerIndex + 1) % playerCount;
            }
            else
            {
                nextPlayerIndex = (_CurrentPlayerIndex + playerCount - 1) % playerCount;
            }

            SetPlayer(nextPlayerIndex.Value);
        }

        private void PreviousPlayer()
        {
            int playerCount = PlayerVMs.Count;
            Direction direction = ServiceLocator<Context>.Instance.SelectedDirection;
            int? nextPlayerIndex;
            if (direction == Direction.CounterClockwise)
            {
                nextPlayerIndex = (_CurrentPlayerIndex + playerCount - 1) % playerCount;
            }
            else
            {
                nextPlayerIndex = (_CurrentPlayerIndex + 1) % playerCount;
            }

            SetPlayer(nextPlayerIndex.Value);
        }

        public void SetPlayer(int nextPlayerIndex)
        {
            bool isPaused = ServiceLocator<Context>.Instance.IsPaused;
            if (!isPaused)
            {
                if (nextPlayerIndex < 0 || nextPlayerIndex >= PlayerVMs.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(nextPlayerIndex), "Player index is out of range.");
                }
                int playerIndex = 0;
                foreach (var player in PlayerVMs)
                {
                    if (playerIndex == nextPlayerIndex)
                    {
                        player.StartTimer();
                        _CurrentPlayerIndex = nextPlayerIndex;
                        CurrentPlayerVM = player;
                    }
                    else
                    {
                        player.StopTimer();
                    }

                    playerIndex++;
                }
            }
        }

        public string GetCurrentPlayerName()
        {
            string currentPlayerName = PlayerVMs[_CurrentPlayerIndex].Player.Name;

            return currentPlayerName;
        }

        public void PlayPause()
        {
            bool isPaused = !ServiceLocator<Context>.Instance.IsPaused;
            ServiceLocator<Context>.Instance.IsPaused = isPaused;

            if (isPaused)
                Pause();
            else
                Play();
        }

        private void Play()
        {
            PlayerVMs[_CurrentPlayerIndex].StartTimer();
        }

        private void Pause()
        {
            PlayerVMs[_CurrentPlayerIndex].StopTimer();
        }

        public void StopGame()
        {
            foreach(var player in PlayerVMs)
            {
                player.Reset();
            }
            _CurrentPlayerIndex = 0;
            ServiceLocator<Context>.Instance.IsPaused = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

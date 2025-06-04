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
    public class GameVM
    {
        public GameVM() 
        {
            _CurrentPlayerIndex = 0;
            PlayerVMs[0].StartTimer();
            NextPlayerCommand = new Command(NextPlayer);
            PreviousPlayerCommand = new Command(PreviousPlayer);
        }

        public ICommand NextPlayerCommand { get; private set; }
        public ICommand PreviousPlayerCommand { get; private set; }
        private int _CurrentPlayerIndex;
        public ObservableCollection<PlayerVM> PlayerVMs => ServiceLocator<Context>.Instance.PlayerVMs;

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
                }
                else
                {
                    player.StopTimer();
                }

                playerIndex++;
            }
        }
    }
}

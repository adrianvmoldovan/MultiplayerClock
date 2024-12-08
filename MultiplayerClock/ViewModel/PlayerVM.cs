using CommunityToolkit.Mvvm.Input;
using MultiplayerClock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiplayerClock.ViewModel
{
    public class PlayerVM : INotifyPropertyChanged
    {
        private Player _Player;
        private IDispatcherTimer _Timer;

        public PlayerVM(Player player)
        {
            _Player = player;
            var dispatcher = Dispatcher.GetForCurrentThread();
            if (dispatcher != null)
            {
                _Timer = dispatcher.CreateTimer();
                _Timer.Interval = TimeSpan.FromSeconds(1);
                _Timer.Tick += OnTimerTick;
            }
            else
            {
                throw new InvalidOperationException("Dispatcher is not available.");
            }
        }

        public Player Player 
        { 
            get => _Player; 
            set
            {
                _Player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        public TimeSpan Time
        {
            get => _Player.Time;
            set
            {
                if (_Player.Time != value)
                {
                    _Player.Time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        public ICommand IncreaseTimeCommand => new RelayCommand(IncreaseTime);
        public ICommand DecreaseTimeCommand => new RelayCommand(DecreaseTime);

        private void OnTimerTick(object? sender, EventArgs e)
        {
            DecreaseTime();
        }

        private void IncreaseTime()
        {
            Time += TimeSpan.FromSeconds(1);
        }

        private void DecreaseTime()
        {
            Time -= TimeSpan.FromSeconds(1);
        }

        public void StartTimer()
        {
            _Timer.Start();
        }

        public void StopTimer()
        {
            _Timer.Stop();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

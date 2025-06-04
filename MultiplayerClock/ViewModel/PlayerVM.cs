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
        private TimeSpan _Time;
        private bool _IsIncreasing;
        private bool _IsPaused;

        public PlayerVM(Player player)
        {
            _Player = player;
            _IsIncreasing = true;
            _IsPaused = false;
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
            get => _Time;
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(TimeDisplay));
                }
            }
        }

        public string TimeDisplay => $"{Time.Minutes:D2}:{Time.Seconds:D2}";

        public ICommand IncreaseTimeCommand => new RelayCommand(IncreaseTime);
        public ICommand DecreaseTimeCommand => new RelayCommand(DecreaseTime);

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_IsIncreasing)
                IncreaseTime();
            else
                DecreaseTime();
        }

        private void IncreaseTime()
        {
            if(!_IsPaused)
                Time += TimeSpan.FromSeconds(1);
        }

        private void DecreaseTime()
        {
            if(!_IsPaused)
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

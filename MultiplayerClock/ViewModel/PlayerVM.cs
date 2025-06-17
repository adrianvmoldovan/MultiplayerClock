using CommunityToolkit.Mvvm.Input;
using MultiplayerClock.Model;
using MultiplayerClock.ViewModel.Services;
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
        private bool _IsPaused;

        public PlayerVM(Player player)
        {
            _Player = player;
            _IsIncreasing = true;
            _IsPaused = false;
            Minutes = 0;
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

            var context = ServiceLocator<Context>.Instance;
            AreFieldsEditable = !context.GameStarted;
            context.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(context.GameStarted))
                {
                    AreFieldsEditable = !context.GameStarted;
                    IsTimeAvailable = !context.GameStarted && context.SelectedGameType == Model.Enums.GameType.SuddenDeath;
                }
                if(e.PropertyName == nameof(context.SelectedGameType))
                {
                    IsTimeAvailable = !context.GameStarted && context.SelectedGameType == Model.Enums.GameType.SuddenDeath;
                    Minutes = context.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 5 : 0;
                    IsIncreasing = context.SelectedGameType == Model.Enums.GameType.Classic;
                }
            };
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

        private bool _AreFieldsEditable = true;
        public bool AreFieldsEditable
        {
            get => _AreFieldsEditable;
            set
            {
                if (_AreFieldsEditable != value)
                {
                    _AreFieldsEditable = value;
                    OnPropertyChanged(nameof(AreFieldsEditable));
                }
            }
        }

        private bool _IsTimeAvailable = false;
        public bool IsTimeAvailable
        {
            get => _IsTimeAvailable;
            set
            {
                if (_IsTimeAvailable != value)
                {
                    _IsTimeAvailable = value;
                    OnPropertyChanged(nameof(IsTimeAvailable));
                }
            }
        }

        private bool _IsIncreasing = true;
        public bool IsIncreasing
        {
            get => _IsIncreasing;
            set
            {
                if (_IsIncreasing != value)
                {
                    _IsIncreasing = value;
                    OnPropertyChanged(nameof(IsIncreasing));
                }
            }
        }

        private int _Minutes;
        public int Minutes
        {
            get => _Minutes;
            set
            {
                int minValue = ServiceLocator<Context>.Instance.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 1 : 0;
                int clamped = Math.Max(minValue, Math.Min(99, value));
                _Minutes = clamped;
                Time = TimeSpan.FromMinutes(_Minutes);
                OnPropertyChanged(nameof(Minutes));
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
        public string MinutesTimeDisplay => $"{Time.Minutes:D2}";

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

        public void Reset()
        {
            _Timer.Stop();

            var context = ServiceLocator<Context>.Instance;
            Minutes = context.SelectedGameType == Model.Enums.GameType.SuddenDeath ? 5 : 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

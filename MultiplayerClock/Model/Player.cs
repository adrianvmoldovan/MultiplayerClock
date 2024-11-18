using MultiplayerClock.Model.Colors;
using System.ComponentModel;
using Microsoft.Maui.Dispatching;

namespace MultiplayerClock.Model
{
    public class Player : INotifyPropertyChanged
    {
        private string           _Name;
        private string           _ColorName;
        private Color            _Color;
        private int              _StartingMinutes;
        private TimeSpan         _RemainingTime;
        private IDispatcherTimer _Timer;
        private string           _TimeLabel;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Player(string name, PossibleColor possibleColor, int minutes = 1)
        {
            _Name          = name;
            _Color         = possibleColor.Color;
            _ColorName     = possibleColor.Name;
            _RemainingTime = TimeSpan.FromMinutes(minutes);
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

            _TimeLabel = _RemainingTime.ToString(@"mm\:ss");
            _StartingMinutes = minutes;
        }

        private void OnTimerTick(object? sender, EventArgs e)
        {
            if (_RemainingTime.TotalSeconds > 0)
            {
                _RemainingTime = _RemainingTime.Subtract(TimeSpan.FromSeconds(1));
                UpdateTimeLabel();
            }
            else
            {
                _Timer.Stop();
            }
        }

        private void UpdateTimeLabel()
        {
            TimeLabel = _RemainingTime.ToString(@"mm\:ss");
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Color Color
        {
            get { return _Color; }
            private set
            {
                _Color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public string ColorName
        {
            get { return _ColorName; }
            private set
            {
                _ColorName = value;
            }
        }

        public string TimeLabel
        {
            get { return _TimeLabel; }
            set
            {
                _TimeLabel = value;
                OnPropertyChanged(nameof(TimeLabel));
            }
        }

        public int StartingMinutes
        {
            get { return _StartingMinutes; }
            set
            {
                _StartingMinutes = value;
                OnPropertyChanged(nameof(StartingMinutes));
            }
        }

        public void SetNewColor(PossibleColor possibleColor)
        {
            Color     = possibleColor.Color;
            ColorName = possibleColor.Name;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

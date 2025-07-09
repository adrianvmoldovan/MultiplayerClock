using MultiplayerClock.Model.Colors;
using System.ComponentModel;
using Microsoft.Maui.Dispatching;

namespace MultiplayerClock.Model
{
    public class Player : INotifyPropertyChanged
    {
        private string   _Name;
        private string   _ColorName;
        private Color    _BkColor;
        private Color    _FwColor;

        public Player(string name, PossibleColor possibleColor, int minutes = 1)
        {
            _Name      = name;
            _BkColor   = possibleColor.BkColor;
            BkColor = _BkColor;
            _FwColor   = possibleColor.FwColor;
            FwColor = _FwColor;
            _ColorName = possibleColor.Name;
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        public Color BkColor
        {
            get { return _BkColor; }
            private set
            {
                _BkColor = value;
                OnPropertyChanged(nameof(BkColor));
            }
        }

        public Color FwColor
        {
            get { return _FwColor; }
            private set
            {
                _FwColor = value;
                OnPropertyChanged(nameof(FwColor));
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

        public void SetNewColor(PossibleColor possibleColor)
        {
            BkColor   = possibleColor.BkColor;
            FwColor   = possibleColor.FwColor;
            ColorName = possibleColor.Name;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

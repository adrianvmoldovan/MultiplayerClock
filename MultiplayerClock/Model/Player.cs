using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiplayerClock.Model
{
    public class Player : INotifyPropertyChanged
    {
        private string   _Name;
        private string   _ColorName;
        private Color    _Color;
        private DateTime _Time;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Player(string name, PossibleColor possibleColor)
        {
            _Name      = name;
            _Color     = possibleColor.Color;
            _ColorName = possibleColor.Name;
            _Time      = DateTime.Now;
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
            get { return _Name; }
            private set
            {
                _Name = value;
            }
        }

        public DateTime Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
                OnPropertyChanged(nameof(Time));
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

using MultiplayerClock.Model.Colors;
using System.ComponentModel;
using Microsoft.Maui.Dispatching;

namespace MultiplayerClock.Model
{
    public class Player
    {
        private string   _Name;
        private string   _ColorName;
        private Color    _Color;
        private TimeSpan _Time;

        public Player(string name, PossibleColor possibleColor, int minutes = 1)
        {
            _Name          = name;
            _Color         = possibleColor.Color;
            _ColorName     = possibleColor.Name;
            _Time = TimeSpan.FromMinutes(minutes);
        }

        public TimeSpan Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        public Color Color
        {
            get { return _Color; }
            private set
            {
                _Color = value;
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
            Color     = possibleColor.Color;
            ColorName = possibleColor.Name;
        }
    }
}

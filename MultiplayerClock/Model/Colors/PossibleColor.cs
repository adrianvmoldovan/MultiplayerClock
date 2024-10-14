using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors
{
    public class PossibleColor : INotifyPropertyChanged
    {
        private bool _IsUsed;

        public event PropertyChangedEventHandler? PropertyChanged;

        public PossibleColor(Color color, string name)
        {
            Color = color;
            IsUsed = false;
            Name = name;
        }


        public Color Color { get; private set; }

        public bool IsUsed
        {
            get
            {
                return _IsUsed;
            }
            private set
            {
                _IsUsed = value;
                OnPropertyChanged(nameof(IsUsed));
            }
        }

        public void SetUsability(bool newValue, IPossibleColorSetter setter)
        {
            if (setter != null)
            {
                IsUsed = newValue;
            }
        }

        public string Name { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

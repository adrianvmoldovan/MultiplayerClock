using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiplayerClock.Model
{
    public class Player /*: INotifyPropertyChanged*/
    {
        private string _Name;
        private Color _Color;
        private DateTime _Time;

        //public event PropertyChangedEventHandler? PropertyChanged;

        public Player(string name, Color color)
        {
            _Name = name;
            _Color = color;
            _Time = DateTime.Now;
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                //OnPropertyChanged(nameof(Name));
            }
        }

        public Color Color
        {
            get { return _Color; }
            set
            {
                _Color = value;
                //OnPropertyChanged(nameof(Color));
            }
        }

        public DateTime Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
                //OnPropertyChanged(nameof(Time));
            }
        }

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}

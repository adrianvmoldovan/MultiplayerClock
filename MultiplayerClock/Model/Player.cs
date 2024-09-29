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
        private string _name;
        private Color _color;
        private DateTime _time;

        //public event PropertyChangedEventHandler PropertyChanged;

        public Player()
        {
            _name = "";
            _color = Colors.Black;
            _time = DateTime.Now;
        }
        public Player(string name, Color color)
        {
            _name = name;
            _color = color;
            _time = DateTime.Now;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                //OnPropertyChanged(nameof(Name));
            }
        }

        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                //OnPropertyChanged(nameof(Color));
            }
        }

        public DateTime Time
        {
            get { return _time; }
            set
            {
                _time = value;
                //OnPropertyChanged(nameof(Time));
            }
        }

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}

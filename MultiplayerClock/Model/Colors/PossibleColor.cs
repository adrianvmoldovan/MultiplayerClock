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
        public event PropertyChangedEventHandler? PropertyChanged;

        public PossibleColor(FwBkColor color, string name)
        {
            BkColor = color.BkColor;
            FwColor = color.FwColor;
            Name = name;
        }


        public Color BkColor { get; private set; }
        public Color FwColor { get; private set; }

        public string Name { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

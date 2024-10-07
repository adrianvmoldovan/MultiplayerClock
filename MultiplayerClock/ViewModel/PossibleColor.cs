using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class PossibleColor
    {
        public PossibleColor(Color color, string name)
        {
            Color = color;
            IsUsed = false;
            Name = name;
        }


        public Color Color { get; private set; }
        public bool IsUsed { get; set; }
        public string Name { get; set; }
    }
}

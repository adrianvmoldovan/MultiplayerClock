using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class PossibleColor
    {
        public PossibleColor(Color color)
        {
            Color = color;
            IsUsed = false;
        }


        public Color Color { get; private set; }
        public bool IsUsed { get; set; }
    }
}

using MultiplayerClock.Model;
using MultiplayerClock.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class ColorSchemeVM
    {
        public ColorSchemeVM(List<PossibleColor> possibleColors) 
        {
            PossibleColors = possibleColors;
        }

        public List<PossibleColor> PossibleColors { get; private set; }

    }
}

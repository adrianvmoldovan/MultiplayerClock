using MultiplayerClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel.Services
{
    public class Context
    {
        public Context() 
        {
            PossibleColorsManager = new PossibleColorsManager();
        }
        public Player? CurrentPlayer { get; set; }
        public PossibleColorsManager PossibleColorsManager { get; set; }
    }
}

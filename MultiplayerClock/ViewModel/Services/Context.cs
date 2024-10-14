using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
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
            ColorsManager = new ColorsManager();
        }
        public Player? CurrentPlayer { get; set; }
        public ColorsManager ColorsManager { get; set; }
    }
}

using MultiplayerClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel.Services
{
    public class SharedPlayerService : ISharedPlayerService
    {
        public Player? SharedPlayer { get; set; }
    }
}

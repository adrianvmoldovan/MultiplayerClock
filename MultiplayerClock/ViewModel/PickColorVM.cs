using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class PickColorVM : IQueryAttributable
    {
        private readonly Context _Context;
        public PickColorVM()
        {
            _Context = new Context();
            PossibleColorsManager = _Context.PossibleColorsManager;
        }

        public PossibleColorsManager PossibleColorsManager { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Player"))
            {
                _Context.CurrentPlayer = query["Player"] as Player;
            }
        }

        public Context GetSharedPlayerService() { return _Context; }
    }
}

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
        private readonly ISharedPlayerService _SharedPlayerService;
        public PickColorVM()
        {
            _SharedPlayerService = new SharedPlayerService();
            PossibleColorsManager = _SharedPlayerService.PossibleColorsManager;
        }

        public PossibleColorsManager PossibleColorsManager { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Player"))
            {
                _SharedPlayerService.SharedPlayer          = query["Player"] as Player;
            }
        }

        public ISharedPlayerService GetSharedPlayerService() { return _SharedPlayerService; }
    }
}

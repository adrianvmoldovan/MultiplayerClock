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
        public PickColorVM()
        {
            var context   = ServiceLocator<Context>.Instance;
            ColorsManager = context.ColorsManager;
        }

        public ColorsManager ColorsManager { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Player"))
            {
                var context = ServiceLocator<Context>.Instance;
                context.CurrentPlayer = query["Player"] as Player;
            }
        }
    }
}

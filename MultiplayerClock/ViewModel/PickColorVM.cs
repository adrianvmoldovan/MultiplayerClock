using MultiplayerClock.Model.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class PickColorVM
    {
        private List<IColorScheme> _ColorSchemes = new List<IColorScheme>();
        private List<Color>        _Colors       = new List<Color>();
        public PickColorVM()
        {
            RegisterSchemes();
        }

        private void RegisterSchemes()
        {
            _ColorSchemes.Add(new BarierScheme   ());
            _ColorSchemes.Add(new DivergingScheme());
            _ColorSchemes.Add(new RainbowScheme  ());
            _ColorSchemes.Add(new WarmScheme     ());
        }
    }
}

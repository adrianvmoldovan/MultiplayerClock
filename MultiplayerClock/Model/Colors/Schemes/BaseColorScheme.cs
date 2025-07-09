using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public abstract class BaseColorScheme : IColorScheme
    {
        public abstract List<FwBkColor> GetColors();
        public abstract string GetName();
        protected List<FwBkColor> GetColors(List<Tuple<string, string>> hexColors)
        {
            List<FwBkColor> colors = new ();
            hexColors.ForEach(color => colors.Add(new FwBkColor(color.Item1, color.Item2)));

            return colors;
        }
    }
}

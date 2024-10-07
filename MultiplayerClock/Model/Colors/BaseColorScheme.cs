using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors
{
    public abstract class BaseColorScheme : IColorScheme
    {
        public abstract List<Color> GetColors();
        public abstract string      GetName();
        protected List<Color> GetColors(List<string> hexColors)
        {
            List<Color> colors = new List<Color>();
            hexColors.ForEach(hexColor => colors.Add(Color.FromArgb(hexColor)));

            return colors;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors
{
    public class WarmScheme : BaseColorScheme
    {
        List<string> _HexColors;
        public WarmScheme()
        {
            _HexColors = new List<string>()
            {
                "ff6961",
                "ffb480",
                "f8f38d",
                "42d6a4",
                "08cad1",
                "59adf6",
                "9d94ff",
                "c780e8",
            };
        }

        public override List<Color> GetColors()
        {
            List<Color> colors = GetColors(_HexColors);

            return colors;
        }
    }
}

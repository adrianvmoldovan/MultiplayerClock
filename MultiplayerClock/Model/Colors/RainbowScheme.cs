using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors
{
    public class RainbowScheme : BaseColorScheme
    {
        List<string> _HexColors;
        public RainbowScheme()
        {
            _HexColors = new List<string>()
            {
                "e6261f",
                "eb7532",
                "f7d038",
                "a3e048",
                "49da9a",
                "34bbe6",
                "4355db",
                "d23be7",
            };
        }

        public override List<Color> GetColors()
        {
            List<Color> colors = GetColors(_HexColors);

            return colors;
        }
    }
}

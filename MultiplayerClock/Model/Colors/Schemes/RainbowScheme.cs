using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class RainbowScheme : BaseColorScheme
    {
        List<Tuple<string, string>> _HexColors;
        public RainbowScheme()
        {
            _HexColors = new ()
            {
                Tuple.Create("e6261f", "ffffff"),
                Tuple.Create("eb7532", "ffffff"),
                Tuple.Create("f7d038", "ffffff"),
                Tuple.Create("a3e048", "ffffff"),
                Tuple.Create("49da9a", "ffffff"),
                Tuple.Create("34bbe6", "ffffff"),
                Tuple.Create("4355db", "ffffff"),
                Tuple.Create("d23be7", "ffffff"),
            };
        }

        public override List<FwBkColor> GetColors()
        {
            List<FwBkColor> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Rainbow";
        }
    }
}

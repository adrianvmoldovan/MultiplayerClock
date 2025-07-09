using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class WarmScheme : BaseColorScheme
    {
        List<Tuple<string, string>> _HexColors;
        public WarmScheme()
        {
            _HexColors = new ()
            {
                Tuple.Create("ff6961", "ffffff"),
                Tuple.Create("ffb480", "ffffff"),
                Tuple.Create("f8f38d", "ffffff"),
                Tuple.Create("42d6a4", "ffffff"),
                Tuple.Create("08cad1", "ffffff"),
                Tuple.Create("59adf6", "ffffff"),
                Tuple.Create("9d94ff", "ffffff"),
                Tuple.Create("c780e8", "ffffff"),
            };
        }

        public override List<FwBkColor> GetColors()
        {
            List<FwBkColor> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Warm";
        }
    }
}

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
                Tuple.Create("ff6961", "000000"),
                Tuple.Create("ffb480", "000000"),
                Tuple.Create("f8f38d", "000000"),
                Tuple.Create("42d6a4", "000000"),
                Tuple.Create("08cad1", "000000"),
                Tuple.Create("59adf6", "000000"),
                Tuple.Create("9d94ff", "000000"),
                Tuple.Create("c780e8", "000000"),
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

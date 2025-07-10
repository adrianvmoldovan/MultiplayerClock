using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class BarierScheme : BaseColorScheme
    {
        List<Tuple<string, string>> _HexColors;
        public BarierScheme()
        {
            _HexColors = new ()
            {
                Tuple.Create("f64f39", "ffffff"),
                Tuple.Create("e7b80a", "ffffff"),
                Tuple.Create("e4d5aa", "000000"),
                Tuple.Create("1587d8", "ffffff"),
                Tuple.Create("524bb3", "ffffff"),
                Tuple.Create("0abc89", "ffffff"),
            };
        }

        public override List<FwBkColor> GetColors()
        {
            List<FwBkColor> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Barier";
        }
    }
}

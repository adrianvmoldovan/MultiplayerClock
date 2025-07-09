using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class DivergingScheme : BaseColorScheme
    {
        List<Tuple<string, string>> _HexColors;
        public DivergingScheme()
        {
            _HexColors = new List<Tuple<string, string>>()
            {
                Tuple.Create("41afaa", "ffffff"),
                Tuple.Create("466eb4", "ffffff"),
                Tuple.Create("00a0e1", "ffffff"),
                Tuple.Create("d7642c", "ffffff"),
                Tuple.Create("af4b91", "ffffff"),
                Tuple.Create("e6a532", "ffffff"),
            };
        }

        public override List<FwBkColor> GetColors()
        {
            List<FwBkColor> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Diverging";
        }
    }
}

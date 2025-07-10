using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class BasicScheme : BaseColorScheme
    {
        List<Tuple<string, string>> _HexColors;
        public BasicScheme()
        {
            _HexColors = new()
            {
                Tuple.Create("0000ff", "ffffff"), //blue
                Tuple.Create("000000", "ffffff"), //black
                Tuple.Create("ffde21", "000000"), //yellow
                Tuple.Create("008000", "ffffff"), //green
                Tuple.Create("ff0000", "ffffff"), //red
                Tuple.Create("ffffff", "000000"), //white
                Tuple.Create("7f00ff", "ffffff"), //violet
            };
        }

        public override List<FwBkColor> GetColors()
        {
            List<FwBkColor> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Basic";
        }
    }
}

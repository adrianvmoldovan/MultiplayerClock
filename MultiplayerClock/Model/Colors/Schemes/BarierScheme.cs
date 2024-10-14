using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class BarierScheme : BaseColorScheme
    {
        List<string> _HexColors;
        public BarierScheme()
        {
            _HexColors = new List<string>()
            {
                "f64f39",
                "e7b80a",
                "e4d5aa",
                "1587d8",
                "524bb3",
                "0abc89",
            };
        }

        public override List<Color> GetColors()
        {
            List<Color> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Barier";
        }
    }
}

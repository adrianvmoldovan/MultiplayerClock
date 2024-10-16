﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public class DivergingScheme : BaseColorScheme
    {
        List<string> _HexColors;
        public DivergingScheme()
        {
            _HexColors = new List<string>()
            {
                "41afaa",
                "466eb4",
                "00a0e1",
                "d7642c",
                "af4b91",
                "e6a532",
            };
        }

        public override List<Color> GetColors()
        {
            List<Color> colors = GetColors(_HexColors);

            return colors;
        }

        public override string GetName()
        {
            return "Diverging";
        }
    }
}

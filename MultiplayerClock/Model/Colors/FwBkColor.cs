using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors
{
    public class FwBkColor
    {
        public FwBkColor(string bkColor, string fwColor)
        {
            FwColor = Color.FromArgb(fwColor);
            BkColor = Color.FromArgb(bkColor);
        }
        public Color FwColor { get; private set; }
        public Color BkColor { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model.Colors.Schemes
{
    public interface IColorScheme
    {
        List<Color> GetColors();
        string GetName();
    }
}

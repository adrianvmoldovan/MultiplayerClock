using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class PickColorVM
    {
        private List<IColorScheme> _ColorSchemes = new List<IColorScheme>();
        private List<Color>        _Colors       = new List<Color>();
        public PickColorVM()
        {
            RegisterSchemes();

            PossibleColorsDictionary = new Dictionary<IColorScheme, List<PossibleColor>>();
            _ColorSchemes.ForEach(colorScheme => PossibleColorsDictionary.Add(colorScheme, CreatePossibleColors(colorScheme.GetColors())));
        }

        private void RegisterSchemes()
        {
            _ColorSchemes.Add(new BarierScheme   ());
            _ColorSchemes.Add(new DivergingScheme());
            _ColorSchemes.Add(new RainbowScheme  ());
            _ColorSchemes.Add(new WarmScheme     ());
        }

        private List<PossibleColor> CreatePossibleColors(List<Color> colors)
        {
            List<PossibleColor> possibleColors = new List<PossibleColor>();
            colors.ForEach(color => possibleColors.Add(new PossibleColor(color)));

            return possibleColors;
        }

        public Dictionary<IColorScheme, List<PossibleColor>> PossibleColorsDictionary { get; set; }

    }
}

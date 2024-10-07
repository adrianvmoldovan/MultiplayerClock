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
    public class PickColorVM : IQueryAttributable
    {
        private List<IColorScheme> _ColorSchemes = new List<IColorScheme>();
        private List<Color>        _Colors       = new List<Color>();
        public PickColorVM()
        {
            RegisterSchemes();

            PossibleColorsDictionary = new Dictionary<IColorScheme, List<PossibleColor>>();
            _ColorSchemes.ForEach(colorScheme => PossibleColorsDictionary.Add(colorScheme, CreatePossibleColors(colorScheme)));
        }

        public Dictionary<IColorScheme, List<PossibleColor>> PossibleColorsDictionary { get; set; }
        public Player? Player { get; set; }

        private void RegisterSchemes()
        {
            _ColorSchemes.Add(new BarierScheme   ());
            _ColorSchemes.Add(new DivergingScheme());
            _ColorSchemes.Add(new RainbowScheme  ());
            _ColorSchemes.Add(new WarmScheme     ());
        }

        private List<PossibleColor> CreatePossibleColors(IColorScheme colorScheme)
        {
            int index = 0;
            List<PossibleColor> possibleColors = new List<PossibleColor>();
            colorScheme.GetColors().ForEach(
                color =>
                {
                    string colorName = colorScheme.GetName() + " " + index++;   //increment the name
                    possibleColors.Add(new PossibleColor(color, colorName));
                });

            return possibleColors;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Player"))
            {
                Player = query["Player"] as Player;
            }
        }
    }
}

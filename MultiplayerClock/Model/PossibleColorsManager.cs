﻿using MultiplayerClock.Model.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model
{
    public class PossibleColorsManager
    {
        private List<IColorScheme> _ColorSchemes = new List<IColorScheme>();

        public PossibleColorsManager()
        {
            RegisterSchemes();
            PossibleColorsDictionary = new Dictionary<IColorScheme, List<PossibleColor>>();
            _ColorSchemes.ForEach(colorScheme => PossibleColorsDictionary.Add(colorScheme, CreatePossibleColors(colorScheme)));
        }

        public Dictionary<IColorScheme, List<PossibleColor>> PossibleColorsDictionary { get; private set; }

        public PossibleColor GetPossibleColor(string colorName)
        {
            //find the possible color by its name
            PossibleColor possibleColor = PossibleColorsDictionary.First(kvp => kvp.Value.Any(pc => pc.Name == colorName)).Value.First(pc => pc.Name == colorName);

            return possibleColor;
        }

        public List<string> GetPossibleColorSchemeNames()
        {
            List<string> possibleColorSchemeNames = new List<string>();
            _ColorSchemes.ForEach(colorScheme => possibleColorSchemeNames.Add(colorScheme.GetName()));

            return possibleColorSchemeNames;
        }

        public List<PossibleColor> GetPossibleColors(string colorSchemeName)
        {
            List<PossibleColor> possibleColors = PossibleColorsDictionary.First(kvp => kvp.Key.GetName() == colorSchemeName).Value;

            return possibleColors;
        }

        private void RegisterSchemes()
        {
            _ColorSchemes.Add(new BarierScheme());
            _ColorSchemes.Add(new DivergingScheme());
            _ColorSchemes.Add(new RainbowScheme());
            _ColorSchemes.Add(new WarmScheme());
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
    }
}

using MultiplayerClock.Model;
using MultiplayerClock.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiplayerClock.ViewModel
{
    public class ColorSchemeVM
    {
        public ColorSchemeVM(string schemeName, List<PossibleColor> possibleColors, Player? player) 
        {
            SchemeName     = schemeName;
            PossibleColors = possibleColors;
            Player         = player;
            ColorSelected  = new Command<object>(async (object obj) => await OnButtonClicked(obj));
        }

        public string SchemeName { get; set; }
        public List<PossibleColor> PossibleColors { get; private set; }
        public Player? Player { get; set; }

        public ICommand ColorSelected {  get; set; }

        public async Task OnButtonClicked(object sender)
        {
            if ((sender as Button) != null && Player != null)
            {
                string colorName = ((Button)sender).AutomationId;
                PossibleColor possibleColor = PossibleColors.First(c => c.Name == colorName);

                Player.Color = possibleColor.Color;
            }

            var navigation = Application.Current?.MainPage?.Navigation;
            if (navigation != null)
            {
                await navigation.PopAsync();
            }
        }
    }
}

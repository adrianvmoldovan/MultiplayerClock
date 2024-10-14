using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiplayerClock.ViewModel
{
    public class ColorSchemeVM
    {
        public ColorSchemeVM(string schemeName) 
        {
            SchemeName     = schemeName;
            var context    = ServiceLocator<Context>.Instance;
            PossibleColors = context.ColorsManager.GetPossibleColors(SchemeName);
            ColorSelected  = new Command<object>(async (object obj) => await OnButtonClicked(obj));
        }

        public string SchemeName { get; set; }
        public List<PossibleColor> PossibleColors { get; private set; }
        public Player? Player { get; set; }
        public ICommand ColorSelected {  get; set; }

        public async Task OnButtonClicked(object sender)
        {
            Button? button = sender as Button;
            var context = ServiceLocator<Context>.Instance;

            if (button != null && context != null && context.CurrentPlayer != null)
            {
                //reset the player color
                string previousColorName = context.CurrentPlayer.ColorName;
                PossibleColor previousPossibleColor = context.ColorsManager.ReservePossibleColors(previousColorName);
                context.ColorsManager.ReleasePossibleColor(previousPossibleColor);

                //set the new player color
                string colorName = button.AutomationId;
                PossibleColor possibleColor = PossibleColors.First(c => c.Name == colorName);
                context.ColorsManager.ReservePossibleColors(possibleColor);
                context.CurrentPlayer.SetNewColor(possibleColor);
            }

            var navigation = Application.Current?.MainPage?.Navigation;
            if (navigation != null)
            {
                await navigation.PopAsync();
            }
        }
    }
}

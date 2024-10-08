using MultiplayerClock.Model;
using MultiplayerClock.View;
using MultiplayerClock.ViewModel.Services;
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
        private readonly ISharedPlayerService _SharedPlayerService;
        public ColorSchemeVM(string schemeName, List<PossibleColor> possibleColors, ISharedPlayerService sharedPlayerService) 
        {
            SchemeName          = schemeName;
            PossibleColors      = possibleColors;
            ColorSelected       = new Command<object>(async (object obj) => await OnButtonClicked(obj));
            _SharedPlayerService = sharedPlayerService;
        }

        public string SchemeName { get; set; }
        public List<PossibleColor> PossibleColors { get; private set; }
        public Player? Player { get; set; }
        public ICommand ColorSelected {  get; set; }

        public async Task OnButtonClicked(object sender)
        {
            if ((sender as Button) != null && _SharedPlayerService.SharedPlayer != null)
            {
                string colorName = ((Button)sender).AutomationId;
                PossibleColor possibleColor = PossibleColors.First(c => c.Name == colorName);

                _SharedPlayerService.SharedPlayer.Color = possibleColor.Color;
            }

            var navigation = Application.Current?.MainPage?.Navigation;
            if (navigation != null)
            {
                await navigation.PopAsync();
            }
        }
    }
}

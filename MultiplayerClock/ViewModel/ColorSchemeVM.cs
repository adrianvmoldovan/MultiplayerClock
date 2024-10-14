﻿using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
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
        private readonly Context _Context;
        public ColorSchemeVM(IServiceProvider serviceProvider, string schemeName) 
        {
            _Context       = serviceProvider.GetRequiredService<Context>();
            SchemeName     = schemeName;
            PossibleColors = _Context.ColorsManager.GetPossibleColors(SchemeName);
            ColorSelected  = new Command<object>(async (object obj) => await OnButtonClicked(obj));
        }

        public string SchemeName { get; set; }
        public List<PossibleColor> PossibleColors { get; private set; }
        public Player? Player { get; set; }
        public ICommand ColorSelected {  get; set; }

        public async Task OnButtonClicked(object sender)
        {
            Button? button = sender as Button;
            if (button != null && _Context.CurrentPlayer != null)
            {
                //reset the player color
                string previousColorName = _Context.CurrentPlayer.ColorName;
                PossibleColor previousPossibleColor = _Context.ColorsManager.ReservePossibleColors(previousColorName);
                _Context.ColorsManager.ReleasePossibleColor(previousPossibleColor);

                //set the new player color
                string colorName = button.AutomationId;
                PossibleColor possibleColor = PossibleColors.First(c => c.Name == colorName);
                _Context.ColorsManager.ReservePossibleColors(possibleColor);
                _Context.CurrentPlayer.SetNewColor(possibleColor);
            }

            var navigation = Application.Current?.MainPage?.Navigation;
            if (navigation != null)
            {
                await navigation.PopAsync();
            }
        }
    }
}

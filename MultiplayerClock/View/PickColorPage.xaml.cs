using MultiplayerClock.Model;
using MultiplayerClock.Model.Colors;
using MultiplayerClock.ViewModel;

namespace MultiplayerClock.View
{ 
    public partial class PickColorPage : ContentPage
    {
        public PickColorPage(PickColorVM vm)
        {
            InitializeComponent();

            Player? player = vm.Player;

            foreach (var pair in vm.PossibleColorsDictionary)
            {
                List<PossibleColor> possibleColors = pair.Value;
                IColorScheme colorScheme           = pair.Key;

                var colorSchemeVM = new ColorSchemeVM(colorScheme.GetName(), possibleColors, player);
                var colorSchemeView = new ColorSchemeView(colorSchemeVM);

                ContentLayout.Children.Add(colorSchemeView);
            }

            BindingContext = vm;
        }
    }
}
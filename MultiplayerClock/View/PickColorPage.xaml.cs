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

            foreach (var pair in vm.PossibleColorsDictionary)
            {
                List<PossibleColor> possibleColors = pair.Value;
                IColorScheme colorScheme           = pair.Key;

                var colorSchemeVM = new ColorSchemeVM(colorScheme.GetName(), possibleColors, vm.GetSharedPlayerService());
                var colorSchemeView = new ColorSchemeView(colorSchemeVM);

                ContentLayout.Children.Add(colorSchemeView);
            }

            BindingContext = vm;
        }
    }
}
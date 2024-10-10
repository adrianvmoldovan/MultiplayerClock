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

            foreach (var colorSchemeName in vm.PossibleColorsManager.GetPossibleColorSchemeNames())
            {
                var colorSchemeVM = new ColorSchemeVM(colorSchemeName, vm.GetSharedPlayerService());
                var colorSchemeView = new ColorSchemeView(colorSchemeVM);

                ContentLayout.Children.Add(colorSchemeView);
            }

            BindingContext = vm;
        }
    }
}
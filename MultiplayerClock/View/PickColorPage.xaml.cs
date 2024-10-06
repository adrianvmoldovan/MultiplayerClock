using MultiplayerClock.ViewModel;

namespace MultiplayerClock.View;

public partial class PickColorPage : ContentPage
{
	public PickColorPage(PickColorVM vm)
	{
		InitializeComponent();
		BindingContext = vm;

        foreach (var pair in vm.PossibleColorsDictionary)
        {
            List<PossibleColor> possibleColors = pair.Value;
            var colorSchemeVM = new ColorSchemeVM(possibleColors);
            var colorSchemeView = new ColorSchemeView(colorSchemeVM);

            ContentLayout.Children.Add(colorSchemeView);
        }
    }
}
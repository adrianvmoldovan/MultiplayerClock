using MultiplayerClock.ViewModel;

namespace MultiplayerClock.View;

public partial class PickColorPage : ContentPage
{
	public PickColorPage(PickColorVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
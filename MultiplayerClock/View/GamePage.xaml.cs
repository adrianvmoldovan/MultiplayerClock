using MultiplayerClock.ViewModel;

namespace MultiplayerClock
{
	public partial class GamePage : ContentPage
	{
		public GamePage(GameVM vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}
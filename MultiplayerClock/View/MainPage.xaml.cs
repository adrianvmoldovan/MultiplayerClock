using MultiplayerClock.ViewModel;

namespace MultiplayerClock
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageVM vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

namespace MultiplayerClock
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel.MainPageVM(3);
        }
    }
}

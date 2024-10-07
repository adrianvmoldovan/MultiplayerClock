using MultiplayerClock.View;

namespace MultiplayerClock
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
            Routing.RegisterRoute(nameof(PickColorPage), typeof(PickColorPage));
        }
    }
}

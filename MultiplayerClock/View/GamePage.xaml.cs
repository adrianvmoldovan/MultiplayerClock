using MultiplayerClock.View;
using MultiplayerClock.ViewModel;

namespace MultiplayerClock
{
	public partial class GamePage : ContentPage
	{
		public GamePage(GameVM vm)
		{
			InitializeComponent();
			BindingContext = vm;

            AddTriangleButtons(vm.GetPoints());
        }

        private void AddTriangleButtons(IList<IList<Point>> shapesPoints)
        {
            var colors = new List<Color>()
            {
                Colors.Red,
                Colors.Green,
                Colors.Brown,
                Colors.BlueViolet,
                Colors.DarkCyan,
                Colors.Gold,
            };

            int i = 0;
            foreach (IList<Point> points in shapesPoints)
            {
                // Create a new GraphicsView
                var triangleButton = new GraphicsView
                {
                    BackgroundColor = Colors.Transparent,
                    Drawable = new TriangleDrawable(points, colors[i]) // Assign the custom drawable
                };

                // Add tap gesture for interactivity
                var tapGesture = new TapGestureRecognizer();
                int buttonIndex = i++; // Capture the current index for use in the handler
                tapGesture.Tapped += (s, e) =>
                {
                    ResultLabel.Text = $"Triangle Button Pressed. You pressed Triangle Button {buttonIndex}!";
                    //DisplayAlert("Triangle Button Pressed", $"You pressed Triangle Button {buttonIndex}!", "OK");
                };
                triangleButton.GestureRecognizers.Add(tapGesture);

                // Add the GraphicsView to the container
                ButtonContainer.Children.Add(triangleButton);
            }
        }
    }
}
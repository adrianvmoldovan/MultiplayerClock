using MultiplayerClock.View;
using MultiplayerClock.ViewModel;
using MultiplayerClock.ViewModel.Services;
using System.Collections.ObjectModel;

namespace MultiplayerClock
{
	public partial class GamePage : ContentPage
	{
		public GamePage(GameVM vm)
		{
			InitializeComponent();
			BindingContext = vm;

            _triangleDrawables = new List<TriangleDrawable>();

            CreateTriangles();
            CreateLabels();
        }

        private IList<TriangleDrawable> _triangleDrawables;

        private void CreateTriangles()
        {
            var players = ServiceLocator<Context>.Instance.PlayerVMs;

            int currentPlayerIndex = 0;
            foreach (var player in players)
            {
                var triangleDrawable = new TriangleDrawable(player.Player.Color, players.Count, currentPlayerIndex);
                _triangleDrawables.Add(triangleDrawable);
                // Create a new GraphicsView
                var triangleGraphic = new GraphicsView
                {
                    BackgroundColor = Colors.Transparent,
                    Drawable = triangleDrawable, // Assign the custom drawable

                };

                triangleGraphic.StartInteraction += (s, e) =>
                {
                    if (e.Touches.Count() > 0)
                    {
                        var tapPoint = e.Touches[0];
                        var pointF = new PointF((float)tapPoint.X, (float)tapPoint.Y);

                        var touchedTriangles = _triangleDrawables.Where(triangle => { return triangle.IsPointInTriangle(pointF); });

                        if (touchedTriangles.Count() > 0)
                        {
                            ResultLabel.Text = $"Triangle Button Pressed. You pressed Triangle Button {touchedTriangles.First().GetPlayerIndex()}!";
                        }
                    }
                };

                // Add the GraphicsView to the container
                ButtonContainer.Children.Add(triangleGraphic);
                currentPlayerIndex++;
            }
        }
    
        private void CreateLabels()
        {
            var players = ServiceLocator<Context>.Instance.PlayerVMs;
            int currentPlayerIndex = 0;
            foreach (var player in players)
            {
                var labelGraphicsView = new GraphicsView
                {
                    Drawable = new TextDrawable(player.Player.Name, players.Count, currentPlayerIndex)
                };
                labelGraphicsView.InputTransparent = true;

                ButtonContainer.Children.Add(labelGraphicsView);

                currentPlayerIndex++;
            }
        }
    }
}
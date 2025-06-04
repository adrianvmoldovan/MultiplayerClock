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

            _TriangleDrawables = new List<TriangleDrawable>();

            CreateTriangles(vm);
            CreateNameFields();
        }

        private IList<TriangleDrawable> _TriangleDrawables;

        private void CreateTriangles(GameVM vm)
        {
            var playerVMs = ServiceLocator<Context>.Instance.PlayerVMs;

            int currentPlayerIndex = 0;
            foreach (var playerVM in playerVMs)
            {
                var triangleDrawable = new TriangleDrawable(playerVM.Player.Color, playerVMs.Count, currentPlayerIndex);
                _TriangleDrawables.Add(triangleDrawable);
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

                        var touchedTriangles = _TriangleDrawables.Where(triangle => { return triangle.IsPointInTriangle(pointF); });

                        if (touchedTriangles.Count() > 0)
                        {
                            int touchedPlayerIndex = touchedTriangles.First().GetPlayerIndex();

                            vm.SetPlayer(touchedPlayerIndex);

                            ResultLabel.Text = $"Triangle Button Pressed. You pressed Triangle Button {touchedPlayerIndex}!";
                        }
                    }
                };

                //var grid = new Grid
                //{
                //    WidthRequest = triangleGraphic.WidthRequest,
                //    HeightRequest = triangleGraphic.HeightRequest
                //};

                var timeLabelCreator = new TimeLabelCreator();
                var label = timeLabelCreator.GetLabel(playerVMs.Count, currentPlayerIndex, (float)triangleGraphic.WidthRequest, (float)triangleGraphic.HeightRequest);

                label.BindingContext = playerVM;
                label.SetBinding(Label.TextProperty, nameof(PlayerVM.TimeDisplay));

                // Add the GraphicsView to the container
                ButtonContainer.Children.Add(triangleGraphic);
                ButtonContainer.Children.Add(label);
                currentPlayerIndex++;
            }
        }
    
        private void CreateNameFields()
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
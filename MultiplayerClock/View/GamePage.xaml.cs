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
            AddLabels();
        }

        private void AddLabels()
        {

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
            foreach (var points in shapesPoints)
            {
                // Create a new GraphicsView
                var triangleButton = new GraphicsView
                {
                    BackgroundColor = Colors.Transparent,
                    Drawable = new TriangleDrawable(points, colors[i]), // Assign the custom drawable

                };

                int buttonIndex = i; // Capture the current index for use in the handler

                // Add tap gesture for interactivity
                var tapGesture = new TapGestureRecognizer
                {
                    Command = new Command<PointF>(tapPoint =>
                    {
                        bool isInside = IsPointInTriangle(tapPoint, points[0], points[1], points[2]);
                        if (isInside)
                        {
                            ResultLabel.Text = $"Triangle Button Pressed. You pressed Triangle Button {buttonIndex}!";
                        }
                    })
                };

                //tapGesture.Tapped += (s, e) =>
                //{
                //    ResultLabel.Text = $"Triangle Button Pressed. You pressed Triangle Button {buttonIndex}!";
                //    //DisplayAlert("Triangle Button Pressed", $"You pressed Triangle Button {buttonIndex}!", "OK");
                //};
                triangleButton.GestureRecognizers.Add(tapGesture);

                // Add the GraphicsView to the container
                ButtonContainer.Children.Add(triangleButton);
                i++;
            }

            int j = 0;
            Point centerPoint = shapesPoints[0][0];
            foreach (var points in shapesPoints)
            {


                var labelGraphicsView = new GraphicsView
                {
                    HeightRequest = 500,
                    WidthRequest = 2000,
                    Drawable = new TextDrawable($"Label {j}", j * 72, centerPoint)
                };

                ButtonContainer.Children.Add(labelGraphicsView);

                j++;
            }
        }

        private static bool IsPointInTriangle(PointF p, PointF p1, PointF p2, PointF p3)
        {
            // Calculate area of the entire triangle
            float area = Math.Abs((p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2.0f);

            // Calculate area of sub-triangle [P, P1, P2]
            float area1 = Math.Abs((p.X * (p1.Y - p2.Y) + p1.X * (p2.Y - p.Y) + p2.X * (p.Y - p1.Y)) / 2.0f);

            // Calculate area of sub-triangle [P, P2, P3]
            float area2 = Math.Abs((p.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p.Y) + p3.X * (p.Y - p2.Y)) / 2.0f);

            // Calculate area of sub-triangle [P, P3, P1]
            float area3 = Math.Abs((p.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p.Y) + p1.X * (p.Y - p3.Y)) / 2.0f);

            // If sum of sub-triangle areas equals original triangle area, point is inside
            return Math.Abs(area - (area1 + area2 + area3)) < 0.01f;
        }

    }
}
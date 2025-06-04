using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.View
{
    public class TextDrawable : IDrawable
    {
        public string Text { get; set; }
        public Color TextColor { get; set; } = Colors.Black;
        public float FontSize { get; set; } = 24;
        public float Degrees { get; set; }
        public float TriangleDegrees { get; set; }
        public Point CenterPoint { get; set; }

        public TextDrawable(string text, int totalNumberOfPlayers, int currentPlayerIndex)
        {
            Text = text;
            TriangleDegrees = 360 / totalNumberOfPlayers;
            Degrees = TriangleDegrees * currentPlayerIndex;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FontSize = FontSize;
            canvas.FontColor = TextColor;

            // Calculate the center of the drawing area
            float centerX = dirtyRect.Center.X;
            float centerY = dirtyRect.Center.Y;

            double radians = TriangleDegrees / 2 * Math.PI / 180;

            //cos alpha = height / hypotenuse
            //alpha = degrees / 2
            //hypotenuse = radius
            float distanceFromCenter = (float)(Math.Cos(radians) * dirtyRect.Center.X);

            // Set the stroke color and size
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;

            //canvas.DrawCircle(centerX, centerY, distanceFromCenter);
            canvas.Translate(0, distanceFromCenter);

            canvas.Rotate(Degrees, centerX, centerY - distanceFromCenter);
            canvas.DrawString(Text, centerX, centerY, HorizontalAlignment.Center);


            canvas.RestoreState();
        }
    }
}

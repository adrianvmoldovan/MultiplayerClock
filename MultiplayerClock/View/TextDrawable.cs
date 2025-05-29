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
        public float Degrees { get; set; } = 72;
        public Point CenterPoint { get; set; }

        public TextDrawable(string text, float degrees, Point centerPoint)
        {
            Text = text;
            Degrees = degrees;
            CenterPoint = centerPoint;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FontSize = FontSize;
            canvas.FontColor = TextColor;

            // Calculate the center of the drawing area
            float centerX = dirtyRect.Center.X;
            float centerY = dirtyRect.Center.Y;

            // Choose a radius (for example, 50)
            float radius = 50;

            // Set the stroke color and size
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;

            canvas.Translate(0, 65);
            // Draw the circle
            canvas.DrawCircle(centerX, centerY, radius);

            canvas.Translate(0, 165);


            canvas.Rotate(Degrees, centerX, centerY - 165);
            canvas.DrawString(Text, centerX, centerY, HorizontalAlignment.Center);


            canvas.RestoreState();
        }
    }
}

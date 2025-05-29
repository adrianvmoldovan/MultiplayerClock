using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.View
{
    class TriangleDrawable : IDrawable
    {
        public TriangleDrawable(IList<Point> points, Color color)
        {
            Points = points;
            Color = color;
        }

        public IList<Point> Points { get; private set; }
        public Color Color{ get; private set; }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var shapePath = new PathF();

            shapePath.MoveTo((float)Points[0].X, (float)Points[0].Y);
            foreach (var point in Points.Skip(1))
            {
                shapePath.LineTo((float)point.X, (float)point.Y);   // Bottom left
            }

            shapePath.Close(); // Connect back to the top center

            canvas.FillColor = Color;
            canvas.FillPath(shapePath);

            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 1;
            canvas.DrawPath(shapePath);
        }
    }
}

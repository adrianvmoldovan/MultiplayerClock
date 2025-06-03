using MultiplayerClock.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.View
{
    class TriangleDrawable : IDrawable
    {
        public TriangleDrawable(Color color, int totalNumberOfPlayers, int currentPlayerIndex)
        {
            _TotalNumberOfPlayers = totalNumberOfPlayers;
            _CurrentPlayerIndex = currentPlayerIndex;
            _color = color;
        }

        private int _TotalNumberOfPlayers;
        private int _CurrentPlayerIndex;
        private Color _color;
        public IList<Point> Points { get; set; } = new List<Point>();

        public int GetPlayerIndex()
        {
            return _CurrentPlayerIndex;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var centerPoint = new Point(dirtyRect.Center.X, dirtyRect.Center.Y);
            float radius = dirtyRect.Width / 2;

            var triangleCreator = new TrianglesCreator();
            Triangle triangle = triangleCreator.GetTriangle(centerPoint, radius, _TotalNumberOfPlayers, _CurrentPlayerIndex);

            Points = triangle.GetPoints();

            var shapePath = new PathF();

            shapePath.MoveTo((float)Points[0].X, (float)Points[0].Y);
            foreach (var point in Points.Skip(1))
            {
                shapePath.LineTo((float)point.X, (float)point.Y);   // Bottom left
            }

            shapePath.Close(); // Connect back to the top center

            canvas.FillColor = _color;
            canvas.FillPath(shapePath);

            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 1;
            canvas.DrawPath(shapePath);
        }

        public bool IsPointInTriangle(PointF p)
        {
            bool result = false;

            if (Points.Count == 3)
            {
                PointF p1 = Points[0];
                PointF p2 = Points[1];
                PointF p3 = Points[2];

                // Calculate area of the entire triangle
                float area = Math.Abs((p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2.0f);

                // Calculate area of sub-triangle [P, P1, P2]
                float area1 = Math.Abs((p.X * (p1.Y - p2.Y) + p1.X * (p2.Y - p.Y) + p2.X * (p.Y - p1.Y)) / 2.0f);

                // Calculate area of sub-triangle [P, P2, P3]
                float area2 = Math.Abs((p.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p.Y) + p3.X * (p.Y - p2.Y)) / 2.0f);

                // Calculate area of sub-triangle [P, P3, P1]
                float area3 = Math.Abs((p.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p.Y) + p1.X * (p.Y - p3.Y)) / 2.0f);

                // If sum of sub-triangle areas equals original triangle area, point is inside
                result = Math.Abs(area - (area1 + area2 + area3)) < 0.01f;
            }


            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model
{
    public class Triangle
    {
        public Triangle(Point pivot, Point second, Point third) 
        {
            Pivot = pivot;
            Second = second;
            Third = third;
        }

        public Point Pivot { get; private set; }
        public Point Second { get; private set; }
        public Point Third { get; private set; }

        public IList<Point> GetPoints()
        {
            return new List<Point>() { Pivot, Second, Third };
        }

        public void Rotate(double angle)
        {
            Second = RotatePoint(Second, angle);
            Third = RotatePoint(Third, angle);
            Pivot = RotatePoint(Pivot, angle);
        }

        private Point RotatePoint(Point point, double angle)
        {
            //The general formula to calculate the new coordinates (x', y') of a point (x, y) after rotation by an angle θ (in radians) around a pivot (px, py) is:
            // 𝑥′ = 𝑝𝑥 + (𝑥 − 𝑝𝑥)⋅cos⁡(𝜃) − (𝑦 − 𝑝𝑦)⋅sin(𝜃)
            // 𝑦′ = 𝑝𝑦 + (𝑥 − 𝑝𝑥)⋅sin(𝜃) + (𝑦 − 𝑝𝑦)⋅cos⁡(𝜃)

            var x = point.X;
            var y = point.Y;

            var px = Pivot.X;
            var py = Pivot.Y;

            var radians = angle * Math.PI / 180;

            var newX = px + (x - px) * Math.Cos(radians) - (y-py) * Math.Sin(radians);
            var newY = py + (x - px) * Math.Sin(radians) + (y -py) * Math.Cos(radians);

            Point newPoint = new Point(newX, newY);

            return newPoint;
        }
    }
}

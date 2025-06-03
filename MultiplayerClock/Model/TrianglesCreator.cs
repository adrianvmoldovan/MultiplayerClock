using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.Model
{
    public class TrianglesCreator
    {
        public TrianglesCreator() 
        {
        }

        public IList<Triangle> GetTriangles(int numberOfTriangles, Point center, double radius)
        {
            double angle = 360 / numberOfTriangles;
            double radians = angle * Math.PI / 180;

            //rotate back so that the first triangle has the base paralel with the x axis
            double forwardAngle = (radians / 2) - (Math.PI / 2);
            double backwardAngle = (- (radians / 2)) - (Math.PI / 2);

            double firstX = center.X + radius * Math.Cos(forwardAngle);
            double firstY = center.Y - radius * Math.Sin(forwardAngle);

            double secondX = center.X + radius * Math.Cos(backwardAngle);
            double secondY = center.Y - radius * Math.Sin(backwardAngle);

            var triangleList = new List<Triangle>();

            for (int i = 0; i < numberOfTriangles; i++)
            {
                var triangle = new Triangle(center, new Point(firstX, firstY), new Point(secondX, secondY));
                double rotatingAngle = angle * i;

                triangle.Rotate(rotatingAngle);
                triangleList.Add(triangle);
            }

            return triangleList;
        }

        public Triangle GetTriangle(Point center, float radius, int totalNumberOfPlayers, int currentPlayerIndex)
        {
            double angle = 360 / totalNumberOfPlayers;
            double radians = angle * Math.PI / 180;

            //rotate back so that the first triangle has the base paralel with the x axis
            double forwardAngle = (radians / 2) - (Math.PI / 2);
            double backwardAngle = (-(radians / 2)) - (Math.PI / 2);

            double firstX = center.X + radius * Math.Cos(forwardAngle);
            double firstY = center.Y - radius * Math.Sin(forwardAngle);

            double secondX = center.X + radius * Math.Cos(backwardAngle);
            double secondY = center.Y - radius * Math.Sin(backwardAngle);

            var triangle = new Triangle(center, new Point(firstX, firstY), new Point(secondX, secondY));
            double rotatingAngle = angle * currentPlayerIndex;

            triangle.Rotate(rotatingAngle);

            return triangle;
        }
    }
}

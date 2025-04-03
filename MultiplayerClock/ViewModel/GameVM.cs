using MultiplayerClock.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.ViewModel
{
    public class GameVM /*: INotifyPropertyChanged*/
    {
        //public event PropertyChangedEventHandler? PropertyChanged;

        public GameVM() 
        {
            // Get screen dimensions
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            double screenWidth = displayInfo.Width / displayInfo.Density;
            double screenHeight = displayInfo.Height / displayInfo.Density;

            // Calculate center coordinates
            double centerX = screenWidth / 2;
            double centerY = screenHeight / 2;

            var trianglesCreator = new TrianglesCreator();
            Triangles = trianglesCreator.GetTriangles(5, new Point(centerX, centerY), centerX);
        }

        private IList<Triangle> Triangles { get; set; }

        public IList<IList<Point>> GetPoints()
        {
            IList<IList<Point>> points = new List<IList<Point>>();
            foreach (var triangle in Triangles)
            {
                points.Add(triangle.GetPoints());
            }

            return points;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerClock.View
{
    public class TimeLabelCreator
    {
        public TimeLabelCreator() 
        {
        }

        public Label GetLabel(int totalNumberOfPlayers, int currentPlayerIndex, float width, float height)
        {
            var label = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            float triangleDegrees = 360 / totalNumberOfPlayers;
            float degrees = triangleDegrees * currentPlayerIndex;

            float centerX = 140/*width / 2*/;
            //float centerY = 150/*height / 2*/;

            float radius = centerX;

            double radians = triangleDegrees / 2 * Math.PI / 180;

            //cos alpha = height / hypotenuse
            //alpha = degrees / 2
            //hypotenuse = radius
            float distanceFromCenter = (float)(Math.Cos(radians) * radius);

            //I have the angle and the distance from the center. Calculate the position of the label in the carthesian coordinates
            float x = (float)(distanceFromCenter * Math.Cos((degrees + 90) * Math.PI / 180));
            float y = (float)(distanceFromCenter * Math.Sin((degrees + 90) * Math.PI / 180));

            label.TranslateTo(x, y);
            label.Rotation = degrees;
            label.FontSize = 24;

            return label;
        }
    }
}

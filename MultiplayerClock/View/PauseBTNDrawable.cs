using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MultiplayerClock.View
{
    public class PauseBTNDrawable : IDrawable
    {
        public PauseBTNDrawable()
        {
            _Radius = 50;
        }

        private int _Radius;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //canvas.FontSize = 24;
            //canvas.FontColor = Colors.White;

            float centerX = dirtyRect.Center.X;
            float centerY = dirtyRect.Center.Y;

            //draw a circle
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;
            canvas.FillColor = (Color)((Microsoft.Maui.Controls.Application.Current?.Resources["Primary"])?? Colors.Transparent);
            //canvas.DrawCircle(centerX, centerY, 50);
            //fill the circle
            canvas.FillCircle(centerX, centerY, _Radius);


            float symbolSize = 45;
            canvas.FontSize = symbolSize;
            var textRect = new RectF(
                centerX - symbolSize / 2,
                centerY - symbolSize / 2,
                symbolSize,
                symbolSize);
            canvas.DrawString("⏸", textRect, HorizontalAlignment.Center, VerticalAlignment.Center);

        }

        public bool IsPointInCircle(PointF p)
        {
            //check if the point is in the circle with the radius _Radius
            bool result = (p.X * p.X + p.Y * p.Y) <= (_Radius * _Radius); ;

            return result;
        }
    }
}

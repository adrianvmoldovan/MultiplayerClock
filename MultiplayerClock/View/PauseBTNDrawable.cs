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
        public PauseBTNDrawable(bool isPaused)
        {
            _Radius = 50;
            _CenterX = 0;
            _CenterY = 0;
            _IsPaused = isPaused;
        }

        private int _Radius;
        private float _CenterX;
        private float _CenterY;
        private bool _IsPaused;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            _CenterX = dirtyRect.Center.X;
            _CenterY = dirtyRect.Center.Y;

            //draw a circle
            canvas.FillColor = (Color)((Microsoft.Maui.Controls.Application.Current?.Resources["Primary"])?? Colors.Transparent);
            canvas.FillCircle(_CenterX, _CenterY, _Radius);

            float symbolSize = 45;
            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 2;
            canvas.DrawCircle(_CenterX, _CenterY, _Radius);

            canvas.FontSize = symbolSize;
            canvas.FontColor = Colors.White;
            var textRect = new RectF(
                _CenterX - symbolSize / 2,
                _CenterY - symbolSize / 2,
                symbolSize,
                symbolSize);

            string symbol = _IsPaused ? "▶" : "| |";

            canvas.DrawString(symbol, textRect, HorizontalAlignment.Center, VerticalAlignment.Center);
        }

        public void TogglePauseBtn()
        {
            _IsPaused = !_IsPaused;
        }

        public bool IsPointInCircle(PointF p)
        {
            float x = p.X - _CenterX;
            float y = p.Y - _CenterY;

            //check if the point is in the circle with the radius _Radius
            bool result = (x * x + y * y) <= (_Radius * _Radius);

            return result;
        }
    }
}

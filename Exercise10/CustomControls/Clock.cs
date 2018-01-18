using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Exercise10.CustomControls
{
    public class Clock : View
    {
        private const int Hour = 12;
        private const int Minute = 60;

        private int currentHour = 0;
        private int currentMinute = 0;
        private int currentSecond = 0;

        private int minuteDividerThin = 2;
        private int minuteDividerLength = 24;
        private int hourDividerThin = 4;
        private int hourDividerLength = 48;
        private int textSize = 50;
        private int needleThin = 16;
        private int borderThin = 10;
        private int margin = 20;

        public Clock(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public Clock(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        public override void Draw(Canvas canvas)
        {
            UpdateClock();

            var xCenter = canvas.Width / 2;
            var yCenter = canvas.Height / 2;
            var radius = Math.Min(xCenter, yCenter) - margin;

            DrawNeedle(xCenter, yCenter, (int)(radius * 0.6), currentHour, Hour, Color.Black, (int)(needleThin * 1), canvas);
            DrawNeedle(xCenter, yCenter, (int)(radius * 0.7), currentMinute, Minute, Color.Black, (int)(needleThin * 0.8), canvas);
            DrawNeedle(xCenter, yCenter, (int)(radius * 0.8), currentSecond, Minute, Color.Black, (int)(needleThin * 0.4), canvas);

            DrawHourNumbers(xCenter, yCenter, (int)(radius * 0.75), Color.Black, textSize, canvas);

            var paint = new Paint
            {
                Color = Color.Gray,
                StrokeWidth = 20
            };
            paint.SetStyle(Paint.Style.Stroke);
            canvas.DrawCircle(xCenter, yCenter, radius, paint);

            paint.Color = Color.Black;
            paint.SetStyle(Paint.Style.Fill);
            canvas.DrawCircle(xCenter, yCenter, (int)(radius * 0.08), paint);

            DrawDivider(xCenter, yCenter, radius, Minute, Color.Black, minuteDividerThin, minuteDividerLength, canvas);
            DrawDivider(xCenter, yCenter, radius, Hour, Color.Black, hourDividerThin, hourDividerLength, canvas);
        }

        public void UpdateClock()
        {
            currentHour = DateTime.Now.Hour;
            currentMinute = DateTime.Now.Minute;
            currentSecond = DateTime.Now.Second;
        }

        private void DrawHourNumbers(int xCenter, int yCenter, int radius, Color color, int size, Canvas canvas)
        {
            var paint = new Paint
            {
                Color = color,
                TextSize = size,
                TextAlign = Paint.Align.Center
            };

            for (var i = 1; i <= 12; i++)
            {
                canvas.DrawText(i.ToString(), GetX(xCenter, radius, i, Hour), GetY(yCenter, radius, i, Hour) + size / 2f, paint);
            }
        }

        private void DrawNeedle(int xCenter, int yCenter, int length, int value, int valueSize, Color color, int thin, Canvas canvas)
        {
            var paint = new Paint
            {
                Color = color,
                StrokeWidth = thin
            };

            canvas.DrawLine(xCenter, yCenter, GetX(xCenter, length, value, valueSize), GetY(yCenter, length, value, valueSize), paint);
        }

        private void DrawDivider(int xCenter, int yCenter, int radius, int valueSize, Color color, int thin, int length, Canvas canvas)
        {
            var paint = new Paint
            {
                Color = color,
                StrokeWidth = thin
            };

            for (var i = 0; i < valueSize; i++)
            {
                var rStart = radius - borderThin / 2;
                var rEnd = rStart - length;
                canvas.DrawLine(
                    GetX(xCenter, rStart, i, valueSize),
                    GetY(yCenter, rStart, i, valueSize),
                    GetX(xCenter, rEnd, i, valueSize),
                    GetY(yCenter, rEnd, i, valueSize),
                    paint);
            }
        }

        private float GetY(int yCenter, int r, int value, int valueSize) =>
            (float)(yCenter - Math.Cos(value * 2 * Math.PI / valueSize) * r);

        private float GetX(int xCenter, int r, int value, int valueSize) =>
            (float)(xCenter + Math.Sin(value * 2 * Math.PI / valueSize) * r);
    }
}
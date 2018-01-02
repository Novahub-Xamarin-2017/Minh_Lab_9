using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace Exercise08.CustomControls
{
    public class CircularProgress : View
    {
        private const int marginValue = 50;

        private int value;
        private int thin;
        
        private Color highlightColor;
        private Color normalColor;
        private Color textColor;

        public CircularProgress(Context context, IAttributeSet attrs) :
            this(context, attrs, 0)
        {
        }

        public CircularProgress(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            var typeArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircularProgress, 0, 0);
            value = typeArray.GetInteger(Resource.Styleable.CircularProgress_value, 50);
            thin = typeArray.GetInteger(Resource.Styleable.CircularProgress_thin, 30);
            highlightColor = typeArray.GetColor(Resource.Styleable.CircularProgress_color_hightligh, Color.Green);
            normalColor = typeArray.GetColor(Resource.Styleable.CircularProgress_color_normal, Color.White);
            textColor = typeArray.GetColor(Resource.Styleable.CircularProgress_color_normal, Color.Black);
        }


        public override void Draw(Canvas canvas)
        {
            DrawArc(canvas, 100, normalColor);
            DrawArc(canvas, value, highlightColor);
            DrawText(canvas, textColor);
        }

        private void DrawArc(Canvas canvas, int value, Color color)
        {
            var size = Math.Min(canvas.Width, canvas.Height) - 2 * marginValue;
            var x = (canvas.Width > canvas.Height ? (canvas.Width - canvas.Height) / 2 : marginValue);
            var y = (canvas.Width > canvas.Height ? marginValue : (canvas.Height - canvas.Width) / 2);

            var paint = new Paint
            {
                StrokeWidth = thin,
                Color = color
            };

            paint.SetStyle(Paint.Style.Stroke);

            canvas.DrawArc(x, y, x + size, y + size, 0, 360f * value / 100, false, paint);
        }

        private void DrawText(Canvas canvas, Color color)
        {
            var size = Math.Min(canvas.Width, canvas.Height) - 2 * marginValue;

            var paint = new Paint
            {
                Color = color,
                TextSize = size / 3f
            };

            var textBound = new Rect();
            paint.SetStyle(Paint.Style.Fill);
            paint.GetTextBounds(value + "%", 0, (value + "%").Length, textBound);

            canvas.DrawText(value + "%", (canvas.Width - textBound.Width()) / 2f, canvas.Height / 2f, paint);
        }
    }
}
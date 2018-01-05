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

namespace Exercise12.CustomControls
{
    public class CircularView : ImageView
    {
        public CircularView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
        }

        public CircularView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var xCenter = canvas.Width / 2;
            var yCenter = canvas.Height / 2;

            var radius = Math.Min(xCenter, yCenter) * 0.9f;

            var paint = new Paint
            {
                StrokeWidth = radius * 2,
                Color = Color.White,
                Flags = PaintFlags.AntiAlias
            };

            paint.SetStyle(Paint.Style.Stroke);

            canvas.DrawCircle(xCenter, yCenter, radius * 2, paint);
            
            paint.StrokeWidth = 20;
            paint.Color = Color.Gray;
            SetLayerType(LayerType.Software, paint);
            paint.SetShadowLayer(16f, 0f, 4f, Color.Black);

            canvas.DrawCircle(xCenter, yCenter, radius, paint);
        }
    }
}
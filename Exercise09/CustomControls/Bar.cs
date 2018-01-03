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

namespace Exercise09.CustomControls
{
    public class Bar : View
    {
        private List<int> values = new List<int>() { 10, 25, 40, 70, 100 };
        public List<int> Values
        {
            get => values;
            set
            {
                this.values = value;
                this.Invalidate();
            }
        }

        public Bar(Context context, IAttributeSet attrs) :
            this(context, attrs, 0)
        {
        }

        public Bar(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        public override void Draw(Canvas canvas)
        {
            var paint = new Paint();
            paint.SetStyle(Paint.Style.Fill);

            var random = new Random();

            var count = 1;
            var margin = 80;
            var height_bar = 50;
            var margin_bar = 15;

            values.ForEach(x =>
            {
                paint.Color = Color.Rgb(random.Next(256), random.Next(256), random.Next(256));

                count++;

                var length = (canvas.Width - 2 * margin) * x / 100f;

                canvas.DrawRect(margin, (count - 1) * (height_bar + 2 * margin_bar), length + margin, count * (height_bar + 2 * margin_bar) - 2 * margin_bar, paint);
            });
        }
    }
}
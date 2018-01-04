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
        public Clock(Context context, IAttributeSet attrs) :
            this(context, attrs, 0)
        {
        }

        public Clock(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

        }
    }
}
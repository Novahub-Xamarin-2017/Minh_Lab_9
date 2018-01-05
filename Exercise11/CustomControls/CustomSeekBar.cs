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
using Com.Lilarcor.Cheeseknife;

namespace Exercise11.CustomControls
{
    public class CustomSeekBar : LinearLayout
    {
        [InjectView(Resource.Id.value)] private TextView tvValue;

        [InjectView(Resource.Id.seekBar)] private SeekBar seekBar;

        private int value;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                this.Invalidate();
            }
        }

        public CustomSeekBar(Context context, IAttributeSet attrs) :
            this(context, attrs, 0)
        {
        }

        public CustomSeekBar(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            var inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.CustomSeekBar, this);
            Cheeseknife.Inject(this, view);

            value = seekBar.Progress;
            Change();

            seekBar.ProgressChanged += (sender, e) => {
                if (!e.FromUser) return;
                value = e.Progress;
                Change();
            };
        }

        [InjectOnClick(Resource.Id.plus)]
        void IncrementValue(object sender, EventArgs e)
        {
            value++;
            Change();
        }

        [InjectOnClick(Resource.Id.sub)]
        void DescrementValue(object sender, EventArgs e)
        {
            value--;
            Change();
        }

        [InjectOnClick(Resource.Id.update)]
        void Update(object sender, EventArgs e)
        {
            Change();
        }

        private void Change()
        {
            tvValue.Text = value.ToString();
            seekBar.SetProgress(value, true);
        }
    }
}
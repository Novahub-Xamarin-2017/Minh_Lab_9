using Android.App;
using Android.Widget;
using Android.OS;
using Exercise10.CustomControls;
using System.Threading;

namespace Exercise10
{
    [Activity(Label = "Exercise10", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Clock clock;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            clock = FindViewById<Clock>(Resource.Id.clock);
            new Thread(Run).Start();
            clock.Invalidate();
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(500);
                RunOnUiThread(clock.PostInvalidate);
            }
        }
    }
}


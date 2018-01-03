using Android.App;
using Android.Widget;
using Android.OS;
using Exercise09.CustomControls;

namespace Exercise09
{
    [Activity(Label = "Exercise09", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var bar = FindViewById<Bar>(Resource.Id.bar);
        }
    }
}


using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace Exercise05
{
    [Activity(Label = "Exercise05", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetActionBar(FindViewById<Toolbar>(Resource.Id.toolbar));

            Init();
        }

        public void Init()
        {
            var adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.states, Android.Resource.Layout.SimpleSpinnerItem);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FindViewById<Spinner>(Resource.Id.state).Adapter = adapter1;

            var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.countries, Android.Resource.Layout.SimpleSpinnerItem);
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            FindViewById<Spinner>(Resource.Id.country).Adapter = adapter2;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}


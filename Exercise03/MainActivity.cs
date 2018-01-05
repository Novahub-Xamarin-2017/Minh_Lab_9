using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;

namespace Exercise03
{
    [Activity(Label = "Exercise03", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.calculate).Click += delegate { Calculate(); };
        }

        public void Calculate()
        {
            var textA = FindViewById<EditText>(Resource.Id.number_a).Text;
            var textB = FindViewById<EditText>(Resource.Id.number_b).Text;
            var textC = FindViewById<EditText>(Resource.Id.number_c).Text;

            var result = "";

            if (textA.Any() && textB.Any() && textC.Any())
            {
                var numberA = int.Parse(textA);
                var numberB = int.Parse(textB);
                var numberC = int.Parse(textC);

                if (numberA == 0)
                {
                    if (numberB == 0)
                    {
                        if (numberC == 0) result = "Phuong trinh vo so nghiem";
                        else result = "Phuong trinh vo nghiem";
                    }
                    else
                    {
                        var x = -numberB / numberC;
                        result = $"Phuong trinh co 1 nghiem: {x}";
                    }
                }
                else
                {
                    var delta = numberB * numberB - 4 * numberA * numberC;

                    if (delta < 0) result = "Phuong trinh vo nghiem";

                    if (delta == 0)
                    {
                        var x = -numberB / (2 * numberA);
                        result = $"Phuong trinh da nghiem kep: {x}";
                    }

                    if (delta > 0)
                    {
                        var x1 = (-numberB + Math.Sqrt(delta)) / (2 * numberA);
                        var x2 = (-numberB - Math.Sqrt(delta)) / (2 * numberA);
                        result = $"Phuong trinh co 2 nghiem phan biet: {x1}, {x2}";
                    }
                }
            } else
            {
                result = "Vui long nhap du lieu";
            }

            FindViewById<TextView>(Resource.Id.result).SetText(result, TextView.BufferType.Editable);
        }
    }
}


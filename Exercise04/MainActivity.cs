using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace Exercise04
{
    [Activity(Label = "Exercise04", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public TextView result;

        public double recentValue = 0;
        public double currentValue = 0;
        public string currentOperator = "";
        public bool hasDot = false;
        public bool reset = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            result = FindViewById<TextView>(Resource.Id.result);

            FindViewById<Button>(Resource.Id.btn_1).Click += delegate { Addvalue("1"); };
            FindViewById<Button>(Resource.Id.btn_2).Click += delegate { Addvalue("2"); };
            FindViewById<Button>(Resource.Id.btn_3).Click += delegate { Addvalue("3"); };
            FindViewById<Button>(Resource.Id.btn_4).Click += delegate { Addvalue("4"); };
            FindViewById<Button>(Resource.Id.btn_5).Click += delegate { Addvalue("5"); };
            FindViewById<Button>(Resource.Id.btn_6).Click += delegate { Addvalue("6"); };
            FindViewById<Button>(Resource.Id.btn_7).Click += delegate { Addvalue("7"); };
            FindViewById<Button>(Resource.Id.btn_8).Click += delegate { Addvalue("8"); };
            FindViewById<Button>(Resource.Id.btn_9).Click += delegate { Addvalue("9"); };
            FindViewById<Button>(Resource.Id.btn_0).Click += delegate { Addvalue("0"); };
            FindViewById<Button>(Resource.Id.btn_dot).Click += delegate { Addvalue("."); };

            FindViewById<Button>(Resource.Id.btn_add).Click += delegate { Operate("+"); };
            FindViewById<Button>(Resource.Id.btn_sub).Click += delegate { Operate("-"); };
            FindViewById<Button>(Resource.Id.btn_mul).Click += delegate { Operate("*"); };
            FindViewById<Button>(Resource.Id.btn_div).Click += delegate { Operate("/"); };
            FindViewById<Button>(Resource.Id.calculate).Click += delegate { Operate("="); };
            FindViewById<Button>(Resource.Id.btn_percent).Click += delegate { Operate("%"); };
            FindViewById<Button>(Resource.Id.btn_c).Click += delegate { Operate("c"); };
            FindViewById<Button>(Resource.Id.btn_delete).Click += delegate { Operate("d"); };

            result = FindViewById<TextView>(Resource.Id.result);
        }

        public void Calculate()
        {
            var check = true;

            switch (currentOperator)
            {
                case "+":
                    recentValue += currentValue;

                    break;
                case "-":
                    recentValue -= currentValue;

                    break;
                case "*":
                    recentValue *= currentValue;

                    break;
                case "/":
                    recentValue /= currentValue;

                    break;
                case "%":
                    recentValue = currentValue / 100;
                    currentOperator = "";

                    break;
                case "":
                    check = false;
                    recentValue = currentValue;

                    break;
            }

            if (check)
            {
                result.SetText(recentValue.ToString(), TextView.BufferType.Editable);
            }
        }

        public void SetCurrentValue(string str)
        {
            result.SetText(str, TextView.BufferType.Editable);
        }

        public void SetValueDefault()
        {
            SetCurrentValue("0");
        }

        public void Operate(string operate)
        {
            currentValue = double.Parse(result.Text);

            if (operate.Equals("c"))
            {
                SetValueDefault();
                recentValue = 0;
                currentValue = 0;
                currentOperator = "";

                return;
            }

            if (operate.Equals("d"))
            {
                if (result.Text.Length > 1)
                {
                    SetCurrentValue(result.Text.Remove(result.Text.Length - 1));
                }
                else
                {
                    SetValueDefault();
                }

                return;
            }

            switch (operate)
            {
                case "+":
                    Calculate();
                    currentOperator = "+";

                    break;
                case "-":
                    Calculate();
                    currentOperator = "-";

                    break;
                case "*":
                    Calculate();
                    currentOperator = "*";

                    break;
                case "/":
                    Calculate();
                    currentOperator = "/";

                    break;
                case "%":
                    currentOperator = "%";
                    Calculate();

                    break;
                case "=":
                    Calculate();
                    currentOperator = "";

                    break;
            }

            reset = true;
        }

        public void Addvalue(string str)
        {
            if (reset)
            {
                SetValueDefault();
                reset = false;
            }

            if (result.Text.Equals("0")) 
            {
                if (str.Equals("."))
                {
                    result.SetText(result.Text + str, TextView.BufferType.Editable);
                }
                else
                {
                    result.SetText(str, TextView.BufferType.Editable);
                }

                return;
            }

            if (str.Equals(".") && result.Text.Any(x => x == '.')) 
            {
                return;
            }

            result.SetText(result.Text + str, TextView.BufferType.Editable);
        }
    }
}


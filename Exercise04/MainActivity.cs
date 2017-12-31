using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Collections.Generic;

namespace Exercise04
{
    [Activity(Label = "Exercise04", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public TextView result;

        public double recentValue = 0;
        public double currentValue = 0;
        public string currentOperator = "";
        public bool reset = false;

        private static List<int> numberButtonIds = new List<int>() {
            Resource.Id.btn_1,
            Resource.Id.btn_2,
            Resource.Id.btn_3,
            Resource.Id.btn_4,
            Resource.Id.btn_5,
            Resource.Id.btn_6,
            Resource.Id.btn_7,
            Resource.Id.btn_8,
            Resource.Id.btn_9,
            Resource.Id.btn_0,
            Resource.Id.btn_dot
        };

        private static List<int> numberOperateIds = new List<int>() {
            Resource.Id.btn_add,
            Resource.Id.btn_sub,
            Resource.Id.btn_mul,
            Resource.Id.btn_div,
            Resource.Id.btn_delete,
            Resource.Id.btn_c,
            Resource.Id.btn_percent,
            Resource.Id.calculate
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            result = FindViewById<TextView>(Resource.Id.result);

            numberButtonIds.ForEach(x => FindViewById<Button>(x).Click += delegate { Addvalue(FindViewById<Button>(x).Text); });

            numberOperateIds.ForEach(x => FindViewById<Button>(x).Click += delegate { Operate(FindViewById<Button>(x).Text.Equals("") ? "d" : FindViewById<Button>(x).Text); });

            result = FindViewById<TextView>(Resource.Id.result);
        }

        public void Calculate()
        {
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
                default:
                    recentValue = currentValue;

                    return;
            }

            SetCurrentValue(recentValue.ToString());
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

            if (operate.Equals("C"))
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

            if (operate.Equals("%"))
            {
                currentOperator = "%";
                Calculate();

                return;
            }

            Calculate();
            currentOperator = string.Equals(operate, "=") ? "" : operate;

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
                    SetCurrentValue(result.Text + str);
                }
                else
                {
                    SetCurrentValue(str);
                }

                return;
            }

            if (str.Equals(".") && result.Text.Contains(".")) 
            {
                return;
            }

            SetCurrentValue(result.Text + str);
        }
    }
}


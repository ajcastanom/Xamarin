using Android.App;
using Android.Widget;
using Android.OS;

namespace App2
{
    [Activity(Label = "App2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Se definen todos los elementos contenidos
        EditText etNumber1, etNumber2;
        TextView tvNumber1, tvNumber2, tvResult;
        Button buttonResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //se asocian las variables a los elementos de la vista
            etNumber1 = FindViewById<EditText>(Resource.Id.editTextNumber1);
            etNumber2 = FindViewById<EditText>(Resource.Id.editTextNumber2);
            tvNumber1 = FindViewById<TextView>(Resource.Id.textViewNumber1);
            tvNumber2 = FindViewById<TextView>(Resource.Id.textViewNumber2);
            tvResult = FindViewById<TextView>(Resource.Id.textViewResult);
            tvNumber2 = FindViewById<TextView>(Resource.Id.textViewNumber2);
            buttonResult = FindViewById<Button>(Resource.Id.buttonResult);

            buttonResult.Click += ButtonResult_Click;
        }

        private void ButtonResult_Click(object sender, System.EventArgs e)
        {
            var result = int.Parse(etNumber1.Text) + int.Parse(etNumber2.Text);
            tvResult.Text = "Resultado: " + result.ToString();
        }
    }
}


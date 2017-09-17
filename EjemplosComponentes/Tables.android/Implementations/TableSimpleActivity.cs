using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Tables.android
{
    [Activity(Label = "Tables.android", MainLauncher = false)]
    class TableSimpleActivity : Activity
    {
        Button buttonReturn;
        string[] data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TableSimple);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;

            TextView titulo = FindViewById<TextView>(Resource.Id.textView1);
            ListView listaNombres = FindViewById<ListView>(Resource.Id.listView1);

            titulo.Text = Intent.GetStringExtra("titulo") ?? "No encontrado";

            string[] data = {
                "Colombia", "Brasil", "Alemania", "Holanda",
                "Monaco","Mongolia","Montserrat","Morocco","Mozambique","Myanmar","Namibia",
                "Iceland","India","Indonesia","Iran","Iraq","Ireland","Israel",
                "United States","United States Minor Outlying Islands","Uruguay"
            };

            this.data = data;

            ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.SimpleListItem, data);

            listaNombres.Adapter = adapter;

            listaNombres.ItemClick += ListaNombres_ItemClick;
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        void ListaNombres_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "Usted ha seleccionado " + data[e.Position] + " en la posición " + e.Position,
            ToastLength.Short).Show();
        }
    }
}
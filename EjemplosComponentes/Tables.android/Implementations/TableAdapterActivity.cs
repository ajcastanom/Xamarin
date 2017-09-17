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
using Tables.android.Models;
using Tables.android.Controls;
using Tables.android.Implementations;

namespace Tables.android
{
    [Activity(Label = "Tables.android", MainLauncher = false)]
    class TableAdapterActivity : Activity
    {
        Button buttonReturn;
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.TableAdapter);

            listView = FindViewById<ListView>(Resource.Id.listViewPlanets);
            listView.ItemClick += HandleEventHandler;
            listView.Adapter = new CustomListAdapter(this, loadPlanets());

            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        void HandleEventHandler(object sender, AdapterView.ItemClickEventArgs e)
        {
            Planet planet = loadPlanets()[e.Position];
            Intent planetDetailActivity = new Intent(this, typeof(PlanetDetailActivity));
            planetDetailActivity.PutExtra("planet", planet);
            StartActivity(planetDetailActivity);
            /*Toast.MakeText(this, "Usted ha seleccionado " + planet.Name + " en la posición " + e.Position,
                           ToastLength.Short).Show();*/
        }

        private List<Planet> loadPlanets()
        {
            List<Planet> Planets = new List<Planet>();
            Planet tierra = new Planet("Tierra", "Tercer planeta");
            tierra.Image = "earth";
            Planets.Add(tierra);

            Planet jupiter = new Planet("Jupiter", "Planeta mas grande");
            jupiter.Image = "jupiter";
            Planets.Add(jupiter);

            return Planets;
        }
    }
}
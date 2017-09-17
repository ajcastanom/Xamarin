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

namespace Tables.android.Implementations
{
    [Activity(Label = "Tables.android", MainLauncher = false)]
    class PlanetDetailActivity : Activity
    {
        TextView textViewName, textViewDescription;
        ImageView imageViewPlanet;
        Button buttonReturn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PlanetDetail);

            textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewDescription = FindViewById<TextView>(Resource.Id.textViewDescription);
            imageViewPlanet = FindViewById<ImageView>(Resource.Id.imageViewPlanet);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;


            Planet planet = (Planet)Intent.GetParcelableExtra("planet");
            textViewName.Text = planet.Name;
            textViewDescription.Text = planet.Description;

            int imageId = Resource.Drawable.default_image;
            if (planet.Image != null)
            {
                switch (planet.Image)
                {
                    case "earth":
                        imageId = Resource.Drawable.earth;
                        break;
                    case "jupiter":
                        imageId = Resource.Drawable.jupiter;
                        break;
                    case "mars":
                        imageId = Resource.Drawable.mars;
                        break;
                }
            }
            imageViewPlanet.SetImageResource(imageId);
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent tableAdapterActivity = new Intent(this, typeof(TableAdapterActivity));
            StartActivity(tableAdapterActivity);
        }
    }
}
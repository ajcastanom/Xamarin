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
using AccenturePeople.android.Models;
using AccenturePeople.android.DataBase;
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class ContactDetailActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
        TextView textViewName, textViewUsername;
        ImageView imageViewContact;
        Button buttonReturn;

        private GoogleMap googleMap;
        private MapFragment mapFragment;

        private LocationManager locationManager;
        private string provider;
        private Location location;
        LatLng Lating;
        LatLng ownLatLng;
        double ownLatitude, ownLongitude;

        public void OnLocationChanged(Location location)
        {
            this.ownLatitude = location.Latitude;
            this.ownLongitude = location.Longitude;

            this.ownLatLng = new LatLng(this.ownLatitude, this.ownLongitude);

            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(this.ownLatLng);
            markerOptions.SetTitle("Aquí estoy!!");

            this.googleMap.AddMarker(markerOptions);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(this.ownLatLng);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            cameraUpdate = CameraUpdateFactory.NewLatLngZoom(this.ownLatLng, 14);
            this.googleMap.MoveCamera(cameraUpdate);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (provider != null)
            {
                this.locationManager.RequestLocationUpdates(provider, 100, 100, this);
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            this.locationManager.RemoveUpdates(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            this.googleMap = googleMap;
            this.OnLocationChanged(this.location);
        }

        public void OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactDetail);

            this.mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.fragmentGoogleMap);

            SetupMap();
            this.locationManager = (LocationManager)GetSystemService(Context.LocationService);
            this.provider = this.locationManager.GetBestProvider(new Criteria(), false);
            this.location = this.locationManager.GetLastKnownLocation(this.provider);
            if (this.location == null)
            {
                System.Diagnostics.Debug.WriteLine("No hay posición");
            }


            textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewUsername = FindViewById<TextView>(Resource.Id.textViewUsername);
            imageViewContact = FindViewById<ImageView>(Resource.Id.imageViewContact);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;

            Contact contact = new Contact();
            String Firstname = contact.Firstname = "anderson";
            String Email = contact.Email = "a@acc.com";
            String Image = contact.Image = "";

            /*String Firstname = Intent.GetStringExtra("firstname");
            String Email = Intent.GetStringExtra("email");
            String Image = Intent.GetStringExtra("image");*/
            textViewName.Text = Firstname;
            textViewUsername.Text = Email;

            int imageId = Resource.Drawable.default_image;
            if (Image != "")
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(Image);
                imageViewContact.SetImageURI(uri);
            }
            else
            {
                imageViewContact.SetImageResource(imageId);
            }
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }

        private void SetupMap()
        {
            if (this.googleMap == null)
            {
                this.mapFragment.GetMapAsync(this);
            }
        }
    }
}
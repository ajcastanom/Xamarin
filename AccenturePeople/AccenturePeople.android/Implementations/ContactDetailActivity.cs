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
using AccenturePeoplePCL.Models;
using AccenturePeople.android.DataBase;
using Android.Gms.Maps;
using Android.Locations;
using Android.Gms.Maps.Model;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false, Theme = "@style/MyTheme")]
    class ContactDetailActivity : AppCompatActivity, IOnMapReadyCallback, ILocationListener
    {
        TextView textViewName, textViewUsername, textViewIdentification, textViewProjectName, textViewWbsName, textViewProfessionalProfile;
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
        string ownLocationName;

        public void OnLocationChanged(Location location)
        {
            //this.ownLatitude = location.Latitude;
            //this.ownLongitude = location.Longitude;

            

            this.ownLatLng = new LatLng(this.ownLatitude, this.ownLongitude);

            MarkerOptions markerOptions = new MarkerOptions();
            markerOptions.SetPosition(this.ownLatLng);
            markerOptions.SetTitle(ownLocationName);

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

            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            toolbar.NavigationClick += Toolbar_NavigationClick;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            this.mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.fragmentGoogleMap);

                        


            textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewIdentification = FindViewById<TextView>(Resource.Id.textViewIdentification);
            textViewUsername = FindViewById<TextView>(Resource.Id.textViewUsername);
            textViewProjectName = FindViewById<TextView>(Resource.Id.textviewProjectName);
            textViewWbsName = FindViewById<TextView>(Resource.Id.textviewWbsName);
            textViewProfessionalProfile = FindViewById<TextView>(Resource.Id.textviewProfessionalProfile);
            imageViewContact = FindViewById<ImageView>(Resource.Id.imageViewContact);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;

            /*Contact contact = new Contact();
            String Firstname = contact.Firstname = "anderson";
            String Email = contact.Email = "a@acc.com";
            String Image = contact.Image = "";*/

            String firstname = Intent.GetStringExtra("firstname");
            String lastname = Intent.GetStringExtra("lastname");
            String identification = Intent.GetStringExtra("identification");
            String username = Intent.GetStringExtra("username");
            String projectName = Intent.GetStringExtra("projectName");
            String wbsName = Intent.GetStringExtra("wbsName");
            String professionalProfile = Intent.GetStringExtra("professionalProfile");
            String locationName = Intent.GetStringExtra("locationName");
            double latitude = double.Parse(Intent.GetStringExtra("latitude"));
            double longitude = double.Parse(Intent.GetStringExtra("longitude"));
            String Image = Intent.GetStringExtra("image");

            textViewName.Text = firstname + " " + lastname;
            textViewIdentification.Text = identification;
            textViewUsername.Text = username;
            textViewProjectName.Text = projectName;
            textViewWbsName.Text = wbsName;
            textViewProfessionalProfile.Text = professionalProfile;
            this.ownLocationName = locationName;
            this.ownLatitude = latitude;
            this.ownLongitude = longitude;

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

            SetupMap();
            this.locationManager = (LocationManager)GetSystemService(Context.LocationService);
            this.provider = this.locationManager.GetBestProvider(new Criteria(), false);
            this.location = this.locationManager.GetLastKnownLocation(this.provider);
            if (this.location == null)
            {
                System.Diagnostics.Debug.WriteLine("No hay posición");
            }
        }

        private void Toolbar_NavigationClick(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            base.OnBackPressed();
        }

        private void SetActionBar(Android.Support.V7.Widget.Toolbar toolbar)
        {
            //throw new NotImplementedException();
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
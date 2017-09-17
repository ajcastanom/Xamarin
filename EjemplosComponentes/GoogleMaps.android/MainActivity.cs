using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Locations;
using Android.Runtime;
using Android.Gms.Maps.Model;
using Android.Content;

namespace GoogleMaps.android
{
    [Activity(Label = "GoogleMaps.android", MainLauncher = true)]
    public class MainActivity : Activity, IOnMapReadyCallback, ILocationListener
    {
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
            if(provider != null)
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
            //throw new System.NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new System.NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            //throw new System.NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.fragmentGoogleMap);

            SetupMap();

            this.locationManager = (LocationManager)GetSystemService(Context.LocationService);
            this.provider = this.locationManager.GetBestProvider(new Criteria(), false);
            this.location = this.locationManager.GetLastKnownLocation(this.provider);
            if(this.location == null)
            {
                System.Diagnostics.Debug.WriteLine("No hay posición");
            }
        }

        private void SetupMap()
        {
            if(this.googleMap == null)
            {
                this.mapFragment.GetMapAsync(this);
            }
        }

    }
}


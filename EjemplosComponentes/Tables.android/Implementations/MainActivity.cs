using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Tables.android
{
    [Activity(Label = "Tables.android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button buttonTableAdapter;
        Button buttonTableSimple;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            buttonTableAdapter = FindViewById<Button>(Resource.Id.buttonTableAdapter);
            buttonTableAdapter.Click += ButtonTableAdapter_Click;

            buttonTableSimple = FindViewById<Button>(Resource.Id.buttonTableSimple);
            buttonTableSimple.Click += ButtonTableSimple_Click;
        }

        private void ButtonTableAdapter_Click(object sender, System.EventArgs e)
        {
            Intent tableAdapterActivity = new Intent(this, typeof(TableAdapterActivity));
            StartActivity(tableAdapterActivity);
        }

        private void ButtonTableSimple_Click(object sender, System.EventArgs e)
        {
            Intent tableSimpleActivity = new Intent(this, typeof(TableSimpleActivity));
            tableSimpleActivity.PutExtra("titulo", Resources.GetString(Resource.String.table_simple));
            StartActivity(tableSimpleActivity);
        }
    }
}


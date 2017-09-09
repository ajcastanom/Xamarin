
using Android.App;
using Android.OS;
using Android.Widget;
using ContactAccentureAndroid.DataBase;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    public class MainActivity : Activity
    {
        TextView textView;
        DataBaseManager dbManager;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Main);

            textView = FindViewById<TextView>(Resource.Id.textViewUser);

            dbManager = new DataBaseManager(this);
            textView.Text = dbManager.getUser()[0].ToString();
        }
    }
}
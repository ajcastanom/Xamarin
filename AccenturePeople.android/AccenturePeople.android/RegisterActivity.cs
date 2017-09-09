
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class RegisterActivity : Activity
    {
        Button buttonLogin;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Register);

            buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);

            buttonLogin.Click += ButtonLogin_Click;
        }

        private void ButtonLogin_Click(object sender, System.EventArgs e)
        {
            var LoginActivity = new Intent(this, typeof(LoginActivity));
            StartActivity(intent: LoginActivity);
        }
    }
}
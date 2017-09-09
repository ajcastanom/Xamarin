
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using ContactAccentureAndroid.DataBase;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = true)]
    class LoginActivity : Activity
    {
        Button buttonRegister, buttonLogin;
        EditText editTextEmail, editTextPassword;
        DataBaseManager dbManager; 
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Login);

            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);
            buttonLogin = FindViewById<Button>(Resource.Id.buttonAccept);

            buttonRegister.Click += ButtonRegister_Click;
            buttonLogin.Click += ButtonLogin_Click;

            dbManager = new DataBaseManager(this);
        }

        private void ButtonLogin_Click(object sender, System.EventArgs e)
        {


            try
            {
                if (string.IsNullOrEmpty(editTextEmail.Text.ToString()) || string.IsNullOrEmpty(editTextPassword.Text.ToString()))
                {
                    Toast.MakeText(this, "Ingrese usuario y contraseña", ToastLength.Short).Show();
                } else
                {
                    var result = dbManager.insertUser(editTextEmail.Text);
                    if (result)
                    {
                        Toast.MakeText(this, "Datos guardados", ToastLength.Short).Show();
                        var mainActivity = new Intent(this, typeof(MainActivity));
                        StartActivity(mainActivity);
                    } else
                    {
                        Toast.MakeText(this, "Error", ToastLength.Short).Show();
                    }
                }

    }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();                
            }
        }

        private void ButtonRegister_Click(object sender, System.EventArgs e)
        {
            var registerActivity = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent: registerActivity);
        }
    }
}
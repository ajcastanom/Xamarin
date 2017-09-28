
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AccenturePeople.android.Utils.Validations;
using AccenturePeople.android.DataBase;
using AccenturePeople.android.Implementations;
using AccenturePeople.android.Models;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false, Theme = "@style/AppThemeNoActionBar")]
    class RegisterActivity : Activity
    {
        Button buttonLogin, buttonAccept;
        EditText editTextEmail, editTextPassword, editConfirmPassword;

        DataBaseManager dbManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Register);

            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            editConfirmPassword = FindViewById<EditText>(Resource.Id.editTextConfirmPassword);

            buttonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            buttonAccept = FindViewById<Button>(Resource.Id.buttonAccept);

            buttonLogin.Click += ButtonLogin_Click;
            buttonAccept.Click += ButtonAccept_Click;

            dbManager = new DataBaseManager(this);
        }

        private void ButtonAccept_Click(object sender, System.EventArgs e)
        {
            try
            {
                Contact contact = new Contact(editTextEmail.Text, editTextPassword.Text);

                if (string.IsNullOrEmpty(editTextEmail.Text.ToString()) || string.IsNullOrEmpty(editTextPassword.Text.ToString())
                    || string.IsNullOrEmpty(editConfirmPassword.Text.ToString()))
                {
                    Toast.MakeText(this, GetString(Resource.String.message_resgister_validate), ToastLength.Short).Show();
                }
                else if (!Email.IsValid(editTextEmail.Text.ToString()))
                {
                    Toast.MakeText(this, GetString(Resource.String.message_credentials_validate), ToastLength.Short).Show();
                }
                else if (editTextPassword.Text.Length < 6)
                {
                    Toast.MakeText(this, GetString(Resource.String.message_password_validate), ToastLength.Short).Show();
                }
                else if(editTextPassword.Text != editConfirmPassword.Text)
                {
                    Toast.MakeText(this, GetString(Resource.String.message_password_length_validate), ToastLength.Short).Show();
                }
                else
                {
                    var result = dbManager.InsertContact(contact);
                    if (result)
                    {
                        Toast.MakeText(this, GetString(Resource.String.save_data), ToastLength.Short).Show();
                        var registerFullActivity = new Intent(this, typeof(RegisterFullActivity));
                        registerFullActivity.PutExtra("contact", contact);
                        StartActivity(registerFullActivity);
                    } else if (result == false)
                    {
                        Toast.MakeText(this, GetString(Resource.String.message_email_exist), ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, GetString(Resource.String.error), ToastLength.Short).Show();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }

        private void ButtonLogin_Click(object sender, System.EventArgs e)
        {
            var LoginActivity = new Intent(this, typeof(LoginActivity));
            StartActivity(intent: LoginActivity);
        }
    }
}
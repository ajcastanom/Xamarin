
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AccenturePeoplePCL.Utils.Validations;
using AccenturePeople.android.DataBase;
using AccenturePeople.android.Implementations;
using AccenturePeoplePCL.Models;
using System.Threading.Tasks;
using AccenturePeople.android.RestServices;
using System;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false, Theme = "@style/AppThemeNoActionBar")]
    class RegisterActivity : Activity
    {
        Button buttonLogin, buttonAccept;
        EditText editTextEmail, editTextPassword, editConfirmPassword;
        ProgressDialog progress;

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

            //dbManager = new DataBaseManager(this);

            Init();
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
                    //var result = dbManager.InsertContact(contact);
                    RegisterEmail(contact);
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

        private void RegisterEmail(Contact contact)
        {
            progress.Show();
            Task.Run(async () =>
            {
                try
                {
                    string response = await AccountRestService.RegisterEmailAsync(contact.Email, contact.Password, contact.Password);
                    if (response == null)
                    {
                        RunOnUiThread(() =>
                        {
                            //Toast.MakeText(this, GetString(Resource.String.save_data), ToastLength.Short).Show();
                            var registerFullActivity = new Intent(this, typeof(RegisterFullActivity));
                            registerFullActivity.PutExtra("email", contact.Email);
                            registerFullActivity.PutExtra("password", contact.Password);
                            StartActivity(intent: registerFullActivity);
                        });
                    }
                    else
                    {
                        RunOnUiThread(() =>
                        {
                            progress.Dismiss();
                            Toast.MakeText(this, response, ToastLength.Short).Show();
                        });
                        
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            });
        }

        private void Init()
        {
            ProgressDialog();
        }

        private void ProgressDialog()
        {
            progress = new Android.App.ProgressDialog(this);
            progress.Indeterminate = true;
            progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
            progress.SetMessage("Cargando...");
            progress.SetInverseBackgroundForced(true);
            progress.SetCancelable(false);
        }
    }
}
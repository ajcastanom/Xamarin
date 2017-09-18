
using Android.App;
using Android.Content;
using Android.OS;
using AccenturePeople.android.DataBase;
using Android.Widget;
using AccenturePeople.android.Utils.Validations;
using AccenturePeoplePCL.Servicios;
using AccenturePeoplePCL.Contratos;
using AccenturePeople.android.Implementations;
using System.Threading.Tasks;
using System;
using AccenturePeople.android.Models;
using System.IO;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = true, Theme = "@style/AppThemeNoActionBar")]
    class LoginActivity : Activity
    {
        Button buttonRegister, buttonLogin;
        EditText editTextEmail, editTextPassword;
        DataBaseManager dbManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //File.Delete("AccenturePeople.db");

            // Create UI
            SetContentView(Resource.Layout.Login);


            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);
            buttonLogin = FindViewById<Button>(Resource.Id.buttonAccept);

            buttonRegister.Click += ButtonRegister_Click;
            buttonLogin.Click += ButtonLogin_Click;

            dbManager = new DataBaseManager(this);
            //dbManager.OnUpgrade(dbManager.ReadableDatabase, 0, 1);
        }

        private void ButtonLogin_Click(object sender, System.EventArgs e)
        {
            Contact contact = new Contact(editTextEmail.Text.ToString(), editTextPassword.Text.ToString());

            try
            {
                if (string.IsNullOrEmpty(contact.Email) || string.IsNullOrEmpty(contact.Password))
                {
                    Toast.MakeText(this, GetString(Resource.String.message_login_validate), ToastLength.Short).Show();
                } else if (!Email.IsValid(contact.Email))
                {
                    Toast.MakeText(this, GetString(Resource.String.message_email_validate), ToastLength.Short).Show();
                }
                else if(dbManager.IsLogin(contact))
                {
                    var mainActivity = new Intent(this, typeof(MainActivity));
                    //mainActivity.PutExtra("contact", contact);
                    StartActivity(mainActivity);
                    //Ir a la actividad de la lista de contactos
                    /*var result = dbManager.insertUser(editTextEmail.Text);
                    if (result)
                    {                        
                        Toast.MakeText(this, GetString(Resource.String.save_data), ToastLength.Short).Show();
                        var mainActivity = new Intent(this, typeof(MainActivity));
                        StartActivity(mainActivity);
                    } else
                    {                        
                        Toast.MakeText(this, GetString(Resource.String.error), ToastLength.Short).Show();
                    }*/
                } else
                {
                    Toast.MakeText(this, GetString(Resource.String.message_credentials_validate), ToastLength.Short).Show();
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

        private void Login()
        {
              
        }
    }
}
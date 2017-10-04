
using Android.App;
using Android.Content;
using Android.OS;
using AccenturePeople.android.DataBase;
using Android.Widget;
using AccenturePeoplePCL.Utils.Validations;
using AccenturePeoplePCL.Servicios;
using AccenturePeoplePCL.Contratos;
using AccenturePeople.android.Implementations;
using System.Threading.Tasks;
using System;
using AccenturePeoplePCL.Models;
using System.IO;
using AccenturePeople.android.RestServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = true, Theme = "@style/AppThemeNoActionBar")]
    class LoginActivity : Activity
    {
        Toast ToastValidateAccount;
        Intent mainActivity;
        Button buttonRegister, buttonLogin;
        EditText editTextEmail, editTextPassword;
        Switch switchRemember;
        DataBaseManager dbManager;
        ProgressDialog progress;

        bool isLoginRemember = false;
        string loginExecute;
        IContactosService contactosService;
        IMobileFirstHelper mobileFirstHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //File.Delete("AccenturePeople.db");

            // Create UI
            SetContentView(Resource.Layout.Login);
            mobileFirstHelper = new MobileFirstHelper();
            contactosService = new ContactosService(mobileFirstHelper);


            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            editTextPassword = FindViewById<EditText>(Resource.Id.editTextPassword);
            switchRemember = FindViewById<Switch>(Resource.Id.switchRemember);
            buttonRegister = FindViewById<Button>(Resource.Id.buttonRegister);
            buttonLogin = FindViewById<Button>(Resource.Id.buttonAccept);

            buttonRegister.Click += ButtonRegister_Click;
            buttonLogin.Click += ButtonLogin_Click;

            dbManager = new DataBaseManager(this);
            dbManager.OnCreate(dbManager.WritableDatabase);
            //dbManager.OnUpgrade(dbManager.ReadableDatabase, 0, 1);

            ToastValidateAccount = Toast.MakeText(this, GetString(Resource.String.message_credentials_validate), ToastLength.Short);

            mainActivity = new Intent(this, typeof(MainActivity));

            loginExecute = Intent.GetStringExtra("loginExecute");

            Init();
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
                else
                {
                    isLoginRemember = false;
                    Login(contact, switchRemember.Checked);
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

        private void Login(Contact contact, bool switchRememberValue)
        {
            progress.Show();
            Task.Run(async () =>
            {
                try
                {                    
                    Login login = await AccountRestService.LoginAsync(contact.Email, contact.Password);                    
                    if (login.Error == null)
                    {
                        if (!isLoginRemember)
                        {
                            //se registra el login
                            short isRemember = 0;
                            if (switchRememberValue)
                            {
                                isRemember = 1;
                            }
                            dbManager.InsertLoginRemember(contact.Email, contact.Password, isRemember);
                        }
                        
                        StartActivity(mainActivity);
                    }
                    else
                    {
                        ToastValidateAccount.Show();
                    }
                    RunOnUiThread(() =>
                    {
                    });

                    progress.Dismiss();
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

            isLoginRemember = true;
            string stringCredentials = dbManager.GetLoginRemember();
            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(stringCredentials);
            
            if(credentials.IsRemember == 1)
            {
                Contact contact = new Contact(credentials.UserName, credentials.Password);
                editTextEmail.Text = contact.Email;
                editTextPassword.Text = contact.Password;
                switchRemember.Checked = true;
                if (loginExecute == null)
                {
                    Login(contact, true);
                }
                
                
            }   
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
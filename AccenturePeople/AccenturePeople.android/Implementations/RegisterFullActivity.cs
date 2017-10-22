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
using Android.Net;
using Refractored.Controls;
using AccenturePeople.android.DataBase;
using System.IO;
using AccenturePeople.android.RestServices;
using AccenturePeoplePCL.Utils;
using AccenturePeoplePCL.Utils.Validations;
using AccenturePeoplePCL.Models;
using System.Threading.Tasks;
using Android.Views.InputMethods;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "Contactos", MainLauncher = false, Theme = "@style/AppTheme")]
    class RegisterFullActivity : Activity
    {
        ImageButton imageButtonChooseImage;
        CircleImageView imageViewProfile;
        EditText editTextIdentification, editTextFirstname, editTextLastname, editTextEmail, editTextProfessionalProfile;
        Button buttonAccept;
        Spinner spinnerProject, spinnerWbs, spinnerLocation;

        private static int PickImageId = 1000;
        private Contact contact;
        DataBaseManager dbManager;
        ProgressDialog progress;


        List<String> listProjectsName, listWbsName, listLocationsName;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.RegisterFull);

            imageButtonChooseImage = FindViewById<ImageButton>(Resource.Id.imageButtonChooseImage);
            imageViewProfile = FindViewById<CircleImageView>(Resource.Id.imageViewProfile);
            editTextIdentification = FindViewById<EditText>(Resource.Id.editTextIdentification);
            editTextFirstname = FindViewById<EditText>(Resource.Id.editTextFirstname);
            editTextLastname = FindViewById<EditText>(Resource.Id.editTextLastname);
            editTextEmail = FindViewById<EditText>(Resource.Id.editTextEmail);
            buttonAccept = FindViewById<Button>(Resource.Id.buttonAccept);
            spinnerProject = FindViewById<Spinner>(Resource.Id.spinnerProject);
            spinnerWbs = FindViewById<Spinner>(Resource.Id.spinnerWbs);
            spinnerLocation = FindViewById<Spinner>(Resource.Id.spinnerLocation);
            editTextProfessionalProfile = FindViewById<EditText>(Resource.Id.editTextProfessionalProfile);

            imageButtonChooseImage.Click += ImageButtonChooseImage_Click;
            buttonAccept.Click += ButtonAccept_Click;

            contact = new Contact();
            contact.Email = Intent.GetStringExtra("email");
            contact.Password = Intent.GetStringExtra("password");
            editTextEmail.Text = contact.Email;

            /*var itemsProjects = new List<string>() { "Seleccione un proyecto", "Proyecto A", "Proyecto B", "Proyecto C", "Proyecto D" };
            var adapterProjects = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, itemsProjects);
            spinnerProject.Adapter = adapterProjects;*/

            /*var itemsWbs = new List<string>() { "Seleccione un WBS", "Wbs 1", "Wbs 2", "Wbs 3", "Wbs 4" };
            var adapterWbs = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, itemsWbs);
            spinnerWbs.Adapter = adapterWbs;*/
            Init();
            InitValuesAsync();

            dbManager = new DataBaseManager(this);
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (editTextIdentification.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, GetString(Resource.String.message_identification_validate), ToastLength.Short).Show();
            }
            else if (editTextFirstname.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, GetString(Resource.String.message_firstname_validate), ToastLength.Short).Show();
            }
            else if (editTextLastname.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, GetString(Resource.String.message_lastname_validate), ToastLength.Short).Show();
            }
            else if (string.IsNullOrEmpty(contact.Email))
            {
                Toast.MakeText(this, GetString(Resource.String.message_login_validate), ToastLength.Short).Show();
            }
            else if (!Email.IsValid(contact.Email))
            {
                Toast.MakeText(this, GetString(Resource.String.message_email_validate), ToastLength.Short).Show();
            }
            else if (spinnerProject.SelectedItemId == 0)
            {
                Toast.MakeText(this, GetString(Resource.String.message_project_validate), ToastLength.Short).Show();
            }
            else if (spinnerWbs.SelectedItemId == 0)
            {
                Toast.MakeText(this, GetString(Resource.String.message_wbs_validate), ToastLength.Short).Show();
            }
            else if (spinnerLocation.SelectedItemId == 0)
            {
                Toast.MakeText(this, GetString(Resource.String.message_location_validate), ToastLength.Short).Show();
            }
            else if (editTextProfessionalProfile.Text.Trim().Equals(""))
            {
                Toast.MakeText(this, GetString(Resource.String.message_professionalprofile_validate), ToastLength.Short).Show();
            }
            else
            {
                contact.Identification = long.Parse(editTextIdentification.Text);
                contact.Firstname = editTextFirstname.Text;
                contact.LastName = editTextLastname.Text;
                contact.Project = Projects.getId(spinnerProject.SelectedItem.ToString()).ToString();
                contact.Wbs = WbsUtil.getId(spinnerWbs.SelectedItem.ToString()).ToString();
                contact.ProfessionalProfile = editTextProfessionalProfile.Text;
                contact.Location = LocationsUtil.getId(spinnerLocation.SelectedItem.ToString()).ToString();

                InsertContact(contact);
            }


           /* var result = dbManager.UpdateContact(contact);
            if (result)
            {
                //se actualiza correctamente el perfil
                Toast.MakeText(this, GetString(Resource.String.save_data), ToastLength.Short).Show();
                var mainActivity = new Intent(this, typeof(MainActivity));
                //mainActivity.PutExtra("contact", contact);
                StartActivity(mainActivity);
            } else
            {
                Toast.MakeText(this, GetString(Resource.String.error), ToastLength.Short).Show();
            }*/
        }

        private void ImageButtonChooseImage_Click(object sender, EventArgs e)
        {   
            Intent intent = new Intent();
            intent.SetType("image/*");

            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Android.Net.Uri uri = data.Data;
                imageViewProfile.SetImageURI(uri);
                contact.Image = uri.ToString();
            }
        }

        public async System.Threading.Tasks.Task InitValuesAsync()
        {
            List<Project> ProjectsResult = await ContactRestService.GetProjects();            
            Projects UtilsProjects = new Projects(ProjectsResult);
            listProjectsName = Projects.getListNames();
            listProjectsName.Insert(0, "Seleccione un proyecto");
            var adapterProjects = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listProjectsName);
            spinnerProject.Adapter = adapterProjects;

            List<Wbs> WbsResult = await ContactRestService.GetWbs();
            WbsUtil UtilsWbs = new WbsUtil(WbsResult);
            listWbsName = WbsUtil.getListNames();
            listWbsName.Insert(0, "Seleccione un WBS");
            var adapterWbs = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listWbsName);
            spinnerWbs.Adapter = adapterWbs;

            List<Locations> LocationResult = await ContactRestService.GetLocation();
            LocationsUtil UtilsLocations = new LocationsUtil(LocationResult);
            listLocationsName = LocationsUtil.getListNames();
            listLocationsName.Insert(0, "Seleccione una ubicación");
            var adapterLocations = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listLocationsName);
            spinnerLocation.Adapter = adapterLocations;
        }

        private void InsertContact(Contact contact)
        {
            progress.Show();
            Task.Run(async () =>
            {
                try
                {
                    Boolean response = await ContactRestService.InsertContactUserAsync(contact);
                    if (response)
                    {
                        /*if (!isLoginRemember)
                        {
                            //se registra el login
                            short isRemember = 0;
                            if (switchRememberValue)
                            {
                                isRemember = 1;
                            }
                            dbManager.InsertLoginRemember(contact.Email, contact.Password, isRemember);
                        }*/
                        RunOnUiThread(() =>
                        {
                            var mainActivity = new Intent(this, typeof(MainActivity));
                            StartActivity(intent: mainActivity);
                        });
                    } else
                    {
                        RunOnUiThread(() =>
                        {
                            progress.Dismiss();
                            Toast.MakeText(this, "Fallo el registro del usuario, vuelva a intentar.", ToastLength.Short).Show();
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

        public override bool OnTouchEvent(MotionEvent e)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(editTextIdentification.WindowToken, 0);
            return base.OnTouchEvent(e);
        }
    }
}
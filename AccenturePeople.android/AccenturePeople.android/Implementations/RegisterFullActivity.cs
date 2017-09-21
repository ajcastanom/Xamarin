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
using AccenturePeople.android.Models;
using AccenturePeople.android.DataBase;
using System.IO;
using AccenturePeople.android.Utils.Validations;
using AccenturePeople.android.RestServices;
using AccenturePeople.android.Utils;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = true, Theme = "@style/AppTheme")]
    class RegisterFullActivity : Activity
    {
        ImageButton imageButtonChooseImage;
        CircleImageView imageViewProfile;
        EditText editTextIdentification, editTextFirstname, editTextLastname, editTextEmail;
        Button buttonAccept;
        Spinner spinnerProject, spinnerWbs;

        private static int PickImageId = 1000;
        private Contact contact;
        DataBaseManager dbManager;

        List<String> listProjectsName, listWbsName;

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

            imageButtonChooseImage.Click += ImageButtonChooseImage_Click;
            buttonAccept.Click += ButtonAccept_Click;

            contact = (Contact)Intent.GetParcelableExtra("contact");
            contact = new Contact();
            //editTextEmail.Text = contact.Email;

            /*var itemsProjects = new List<string>() { "Seleccione un proyecto", "Proyecto A", "Proyecto B", "Proyecto C", "Proyecto D" };
            var adapterProjects = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, itemsProjects);
            spinnerProject.Adapter = adapterProjects;*/

            /*var itemsWbs = new List<string>() { "Seleccione un WBS", "Wbs 1", "Wbs 2", "Wbs 3", "Wbs 4" };
            var adapterWbs = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, itemsWbs);
            spinnerWbs.Adapter = adapterWbs;*/

            InitValuesAsync();

            dbManager = new DataBaseManager(this);
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            contact.Identification = long.Parse(editTextIdentification.Text);
            contact.Firstname = editTextFirstname.Text;
            contact.LastName = editTextLastname.Text;
            contact.Project = "";
            contact.Wbs = "";
            contact.ProfessionalProfile = "";
            contact.Location = "";

            if (string.IsNullOrEmpty(contact.Email))
            {
                Toast.MakeText(this, GetString(Resource.String.message_login_validate), ToastLength.Short).Show();
            }
            else if (!Email.IsValid(contact.Email))
            {
                Toast.MakeText(this, GetString(Resource.String.message_email_validate), ToastLength.Short).Show();
            }
            else if (dbManager.IsLogin(contact))
            {
            }

                var result = dbManager.UpdateContact(contact);
            if (result)
            {
                //se actualiza correctamente el perfil
                Toast.MakeText(this, GetString(Resource.String.save_data), ToastLength.Short).Show();
                var mainActivity = new Intent(this, typeof(MainActivity));
                mainActivity.PutExtra("contact", contact);
                StartActivity(mainActivity);
            } else
            {
                Toast.MakeText(this, GetString(Resource.String.error), ToastLength.Short).Show();
            }
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
            listProjectsName = UtilsProjects.getListNames();
            listProjectsName.Insert(0, "Seleccione un proyecto");
            var adapterProjects = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listProjectsName);
            spinnerProject.Adapter = adapterProjects;

            List<Wbs> WbsResult = await ContactRestService.GetWbs();
            WbsUtil UtilsWbs = new WbsUtil(WbsResult);
            listWbsName = UtilsProjects.getListNames();
            listWbsName.Insert(0, "Seleccione un WBS");
            var adapterWbs = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, listWbsName);
            spinnerWbs.Adapter = adapterWbs;
        }
    }
}
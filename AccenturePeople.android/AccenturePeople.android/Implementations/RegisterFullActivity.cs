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

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false, Theme = "@style/AppTheme")]
    class RegisterFullActivity : Activity
    {
        ImageButton imageButtonChooseImage;
        CircleImageView imageViewProfile;
        EditText editTextIdentification, editTextFirstname, editTextLastname, editTextEmail;
        Button buttonAccept;

        private static int PickImageId = 1000;
        private Contact contact;
        DataBaseManager dbManager;

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

            imageButtonChooseImage.Click += ImageButtonChooseImage_Click;
            buttonAccept.Click += ButtonAccept_Click;

            contact = (Contact)Intent.GetParcelableExtra("contact");
            editTextEmail.Text = contact.Email;

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
    }
}
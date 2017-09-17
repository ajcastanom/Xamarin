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

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = true, Theme = "@style/AppTheme")]
    class RegisterFullActivity : Activity
    {
        ImageButton imageButtonChooseImage;
        CircleImageView imageViewProfile;
        EditText editTextIdentification, editTextFirstname, editTextLastname, editTextEmail;

        private static int PickImageId = 1000;


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

            imageButtonChooseImage.Click += ImageButtonChooseImage_Click;
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
            }
        }
    }
}
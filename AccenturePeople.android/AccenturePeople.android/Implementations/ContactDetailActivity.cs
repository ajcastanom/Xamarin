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
using AccenturePeople.android.Models;
using AccenturePeople.android.DataBase;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class ContactDetailActivity : Activity
    {
        TextView textViewName, textViewUsername;
        ImageView imageViewContact;
        Button buttonReturn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactDetail);

            textViewName = FindViewById<TextView>(Resource.Id.textViewName);
            textViewUsername = FindViewById<TextView>(Resource.Id.textViewUsername);
            imageViewContact = FindViewById<ImageView>(Resource.Id.imageViewContact);
            buttonReturn = FindViewById<Button>(Resource.Id.buttonReturn);
            buttonReturn.Click += ButtonReturn_Click;


            String Firstname = Intent.GetStringExtra("firstname");
            String Email = Intent.GetStringExtra("email");
            String Image = Intent.GetStringExtra("image");
            textViewName.Text = Firstname;
            textViewUsername.Text = Email;

            int imageId = Resource.Drawable.default_image;
            if (Image != "")
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(Image);
                imageViewContact.SetImageURI(uri);
            }
            else
            {
                imageViewContact.SetImageResource(imageId);
            }
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
        }
    }
}
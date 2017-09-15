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


            Contact contact = (Contact)Intent.GetParcelableExtra("contact");
            textViewName.Text = contact.Name;
            textViewUsername.Text = contact.Username;

            int imageId = Resource.Drawable.default_image;
            if (contact.Image != null)
            {
                switch (contact.Image)
                {
                    case "aristoteles":
                        imageId = Resource.Drawable.aristoteles;
                        break;
                    case "platon":
                        imageId = Resource.Drawable.platon;
                        break;
                }
            }
            imageViewContact.SetImageResource(imageId);
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }
    }
}
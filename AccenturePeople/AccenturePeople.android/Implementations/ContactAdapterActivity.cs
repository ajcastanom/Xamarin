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

using AccenturePeoplePCL.Models;
using AccenturePeople.android.Controls;
using AccenturePeople.android.DataBase;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class ContactAdapterActivity : Activity
    {
        ListView listViewContacts;
        DataBaseManager dbManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dbManager = new DataBaseManager(this);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactAdapter);

            listViewContacts = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContacts.ItemClick += HandleEventHandler;
            listViewContacts.Adapter = new CustomListAdapter(this, LoadContacts());
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        void HandleEventHandler(object sender, AdapterView.ItemClickEventArgs e)
        {
            Contact contact = LoadContacts()[e.Position];
            Intent contactDetailActivity = new Intent(this, typeof(ContactDetailActivity));
            contactDetailActivity.PutExtra("firstname", contact.Firstname);
            contactDetailActivity.PutExtra("email", contact.Email);
            contactDetailActivity.PutExtra("image", contact.Image);
            StartActivity(contactDetailActivity);
            /*Toast.MakeText(this, "Usted ha seleccionado " + planet.Name + " en la posición " + e.Position,
                           ToastLength.Short).Show();*/
        }

        private List<Contact> LoadContacts()
        {
            List<Contact> Contacts = dbManager.GetContacts();
            return Contacts;
        }
    }
}
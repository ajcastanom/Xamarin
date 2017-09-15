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
using AccenturePeople.android.Controls;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class ContactAdapterActivity : Activity
    {
        ListView listViewContacts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactAdapter);

            listViewContacts = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContacts.ItemClick += HandleEventHandler;
            listViewContacts.Adapter = new CustomListAdapter(this, loadContacts());
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        void HandleEventHandler(object sender, AdapterView.ItemClickEventArgs e)
        {
            Contact contact = loadContacts()[e.Position];
            /*Intent planetDetailActivity = new Intent(this, typeof(PlanetDetailActivity));
            planetDetailActivity.PutExtra("contact", contact);
            StartActivity(planetDetailActivity);
            /*Toast.MakeText(this, "Usted ha seleccionado " + planet.Name + " en la posición " + e.Position,
                           ToastLength.Short).Show();*/
        }

        private List<Contact> loadContacts()
        {
            List<Contact> Contacts = new List<Contact>();
            Contact contact = new Contact("Aristoteles", "Filosofo", "Grecia", "aristoteles");
            Contacts.Add(contact);

            contact = new Contact("Platón", "Otro Filosofo", "Grecia", "platon");
            Contacts.Add(contact);

            return Contacts;
        }
    }
}
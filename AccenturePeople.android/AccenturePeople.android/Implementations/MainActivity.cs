
using Android.App;
using Android.Views;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using AccenturePeople.android.Fragments;
using Android.Widget;
using AccenturePeople.android.Controls;
using Android.Content;
using AccenturePeople.android.Models;
using System;
using System.Collections.Generic;
using AccenturePeople.android.Implementations;

namespace AccenturePeople.android
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        ListView listViewContacts;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create UI
            SetContentView(Resource.Layout.Main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // Init toolbar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            listViewContacts = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContacts.ItemClick += HandleEventHandler;
            listViewContacts.Adapter = new CustomListAdapter(this, loadContacts());

        }

        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {

            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    var trans = SupportFragmentManager.BeginTransaction();
                    trans.Add(Resource.Id.ContentFrameLayout, new ContactsFragment(), "Contacts");
                    trans.Commit();
                    break;
            }

            // Close drawer
            drawerLayout.CloseDrawers();
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            Intent mainActivity = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivity);
        }

        void HandleEventHandler(object sender, AdapterView.ItemClickEventArgs e)
        {
            Contact contact = loadContacts()[e.Position];
            Intent contactDetailActivity = new Intent(this, typeof(ContactDetailActivity));
            contactDetailActivity.PutExtra("contact", contact);
            StartActivity(contactDetailActivity);
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
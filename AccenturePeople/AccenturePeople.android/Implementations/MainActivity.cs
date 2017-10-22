
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
using AccenturePeoplePCL.Models;
using System;
using System.Collections.Generic;
using AccenturePeople.android.Implementations;
using AccenturePeople.android.DataBase;
using System.Threading.Tasks;
using AccenturePeople.android.RestServices;

namespace AccenturePeople.android
{
    [Activity(Label = "Contactos", MainLauncher = false, Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        SearchView searchViewFilter;
        ListView listViewContacts;

        DataBaseManager dbManager;
        ProgressDialog progress;
        List<ContactService> contacts;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            dbManager = new DataBaseManager(this);

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

            searchViewFilter = FindViewById<SearchView>(Resource.Id.searchViewFilter);
            searchViewFilter.QueryTextChange += SearchViewFilter_QueryTextChange;

            listViewContacts = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContacts.ItemClick += HandleEventHandler;
            //listViewContacts.Adapter = new CustomListAdapter(this, LoadContacts());
            Init();
            GetAllUser();
        }

        private void SearchViewFilter_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            ((CustomListAdapter)listViewContacts.Adapter).Filter(e.NewText);
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
                case (Resource.Id.nav_logout):
                    Intent loginActivity = new Intent(this, typeof(LoginActivity));
                    loginActivity.PutExtra("loginExecute", "false");
                    StartActivity(loginActivity);
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
            ContactService contact = contacts[e.Position];
            Intent contactDetailActivity = new Intent(this, typeof(ContactDetailActivity));
            contactDetailActivity.PutExtra("firstname", contact.FirstName);
            contactDetailActivity.PutExtra("lastname", contact.LastName);
            contactDetailActivity.PutExtra("identification", contact.IdDocument);
            contactDetailActivity.PutExtra("username", contact.UserAcc);
            contactDetailActivity.PutExtra("projectName", contact.ProjectName);
            contactDetailActivity.PutExtra("wbsName", contact.Wbsname);
            contactDetailActivity.PutExtra("professionalProfile", contact.ProfessionalProfile);
            contactDetailActivity.PutExtra("locationName", contact.LocationName);
            contactDetailActivity.PutExtra("latitude", contact.Latitude.ToString());
            contactDetailActivity.PutExtra("longitude", contact.Longitude.ToString());
            contactDetailActivity.PutExtra("image", "");
            StartActivity(contactDetailActivity);
        }

        private List<Contact> LoadContacts()
        {
            List<Contact> Contacts = dbManager.GetContacts();
            
            return Contacts;
        }

        public override void OnBackPressed()
        {
            return;
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

        private void GetAllUser()
        {
            progress.Show();
            Task.Run(async () =>
            {
                try
                {
                    List<ContactService> contacts = await ContactRestService.GetAllUser();
                    RunOnUiThread(() =>
                    {
                        this.contacts = contacts;
                        listViewContacts.Adapter = new CustomListAdapter(this, contacts);
                        progress.Dismiss();
                        
                    });                    
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            });
        }
    }
}
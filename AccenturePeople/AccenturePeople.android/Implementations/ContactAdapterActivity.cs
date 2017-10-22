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
using System.Threading.Tasks;
using AccenturePeople.android.RestServices;

namespace AccenturePeople.android.Implementations
{
    [Activity(Label = "AccenturePeople.android", MainLauncher = false)]
    class ContactAdapterActivity : Activity
    {
        ListView listViewContacts;
        DataBaseManager dbManager;

        ProgressDialog progress;
        List<ContactService> contacts;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            dbManager = new DataBaseManager(this);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ContactAdapter);

            listViewContacts = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContacts.ItemClick += HandleEventHandler;
            //listViewContacts.Adapter = new CustomListAdapter(this, LoadContacts());
            Init();
            GetAllUser();
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
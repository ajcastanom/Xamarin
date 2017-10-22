using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

using AccenturePeoplePCL.Models;

namespace AccenturePeople.android.Controls
{
    class CustomListAdapter : BaseAdapter<ContactService>
    {
        Activity context;
        List<ContactService> contacts;

        public CustomListAdapter(Activity _context, List<ContactService> _contacts)
            : base()
        {
            this.context = _context;
            this.contacts = _contacts;
        }

        public override int Count
        {
            get { return contacts.Count; }
        }

        public override ContactService this[int position]
        {
            get { return contacts[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);
            }

            ContactService contact = this[position];
            view.FindViewById<TextView>(Resource.Id.Name).Text = contact.FirstName;
            view.FindViewById<TextView>(Resource.Id.Username).Text = contact.UserAcc;
            view.FindViewById<TextView>(Resource.Id.Location).Text = contact.LocationName;
            var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail);
            //borrar si se resuelve carga de imagenes
            int imageId = Resource.Drawable.default_image;
            imageView.SetImageResource(imageId);
            /*
            int imageId = Resource.Drawable.default_image;
            if (contact.Image != null && contact.Image != "")
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(contact.Image);
                imageView.SetImageURI(uri);
            } else
            {
                imageView.SetImageResource(imageId);
            }*/
            
            return view;
        }
    }
}
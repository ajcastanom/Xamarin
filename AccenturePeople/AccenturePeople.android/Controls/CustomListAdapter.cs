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

namespace AccenturePeople.android.Controls
{
    class CustomListAdapter : BaseAdapter<Contact>
    {
        Activity context;
        List<Contact> contacts;

        public CustomListAdapter(Activity _context, List<Contact> _contacts)
            : base()
        {
            this.context = _context;
            this.contacts = _contacts;
        }

        public override int Count
        {
            get { return contacts.Count; }
        }

        public override Contact this[int position]
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

            Contact contact = this[position];
            view.FindViewById<TextView>(Resource.Id.Name).Text = contact.Firstname;
            view.FindViewById<TextView>(Resource.Id.Username).Text = contact.Email;
            var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail);

            int imageId = Resource.Drawable.default_image;
            if (contact.Image != null && contact.Image != "")
            {
                Android.Net.Uri uri = Android.Net.Uri.Parse(contact.Image);
                imageView.SetImageURI(uri);
            } else
            {
                imageView.SetImageResource(imageId);
            }
            
            return view;
        }
    }
}
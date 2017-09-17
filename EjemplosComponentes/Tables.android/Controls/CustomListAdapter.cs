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
using Tables.android.Models;

namespace Tables.android.Controls
{
    class CustomListAdapter : BaseAdapter<Planet>
    {
        Activity context;
        List<Planet> planets;

        public CustomListAdapter(Activity _context, List<Planet> _planets)
            :base()
        {
            this.context = _context;
            this.planets = _planets;
        }

        public override int Count
        {
            get { return planets.Count; }
        }

        public override Planet this[int position]
        {
            get { return planets[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if(view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);
            }

            Planet planet = this[position];
            view.FindViewById<TextView>(Resource.Id.Title).Text = planet.Name;
            view.FindViewById<TextView>(Resource.Id.Description).Text = planet.Description;
            var imageView = view.FindViewById<ImageView>(Resource.Id.Thumbnail);

            int imageId = Resource.Drawable.default_image;
            if (planet.Image != null)
            {
                switch (planet.Image)
                {
                    case "earth":
                        imageId = Resource.Drawable.earth;
                        break;
                    case "jupiter":
                        imageId = Resource.Drawable.jupiter;
                        break;
                    case "mars":
                        imageId = Resource.Drawable.mars;
                        break;
                }
            }
            imageView.SetImageResource(imageId);
            return view;
        }
    }
}
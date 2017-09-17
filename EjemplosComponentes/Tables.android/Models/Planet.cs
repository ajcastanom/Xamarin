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
using Java.Interop;
using Tables.android.Creators;

namespace Tables.android.Models
{
    class Planet : Java.Lang.Object, IParcelable
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }

        public Planet(string _name, string _description)
        {
            this.Name = _name;
            this.Description = _description;
        }

        public Planet(string _name, string _description, string _image)
        {
            this.Name = _name;
            this.Description = _description;
            this.Image = _image;
        }

        [ExportField("CREATOR")]
        public static PlanetCreator InititalizeCreator()
        {
            return new PlanetCreator();
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(this.Name);
            dest.WriteString(this.Description);
            dest.WriteString(this.Image);
        }
    }
}
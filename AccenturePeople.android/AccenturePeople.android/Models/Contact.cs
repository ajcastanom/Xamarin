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
using AccenturePeople.android.Creators;

namespace AccenturePeople.android.Models
{
    class Contact : Java.Lang.Object, IParcelable
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

        public Contact(String _name, String _username, String _location, String _image)
        {
            this.Name = _name;
            this.Username = _username;
            this.Location = _location;
            this.Image = _image;
        }

        [ExportField("CREATOR")]
        public static ContactCreator InititalizeCreator()
        {
            return new ContactCreator();
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteString(this.Name);
            dest.WriteString(this.Username);
            dest.WriteString(this.Location);
            dest.WriteString(this.Image);
        }
    }
}
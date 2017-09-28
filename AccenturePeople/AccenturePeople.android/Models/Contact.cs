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
        public long Identification { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Project { get; set; }
        public string Wbs { get; set; }
        public string ProfessionalProfile { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }

        public Contact(){}

        public Contact(String _email, String _password)
        {
            this.Email = _email;
            this.Password = _password;
        }

        public Contact(long _identification, String _firstname, String _lastname, String _email, 
            String _password, String _project, String _wbs, String _professionalProfile, String _location, String _image)
        {
            this.Identification = _identification;
            this.Firstname = _firstname;
            this.LastName = _lastname;
            this.Email = _email;
            this.Password = _password;
            this.Project = _project;
            this.Wbs = _wbs;
            this.ProfessionalProfile = _professionalProfile;
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
            dest.WriteLong(this.Identification);
            dest.WriteString(this.Firstname);
            dest.WriteString(this.LastName);
            dest.WriteString(this.Email);
            dest.WriteString(this.Project);
            dest.WriteString(this.Wbs);
            dest.WriteString(this.ProfessionalProfile);
            dest.WriteString(this.Location);
            dest.WriteString(this.Image);
        }
    }
}
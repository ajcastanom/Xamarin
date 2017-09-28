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
using Java.Util;
using AccenturePeople.android.Models;

namespace AccenturePeople.android.Utils
{
    class LocationsUtil
    {
        private HashMap locationsId;
        private List<Locations> locations;

        public LocationsUtil(List<Locations> _locations)
        {
            this.locationsId = new HashMap();
            this.locations = _locations;

            foreach (Locations location in _locations)
            {
                this.locationsId.Put(location.Name, location.Id);
            }
        }

        public long getId(string name)
        {
            return long.Parse(locationsId.Get(name).ToString());
        }

        public List<String> getListNames()
        {
            List<string> listNames = new List<string>();
            foreach (Locations location in locations)
            {
                listNames.Add(location.Name);
            }

            return listNames;
        }
    }
}
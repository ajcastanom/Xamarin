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
using Newtonsoft.Json;

namespace AccenturePeople.android.Models
{
    class Locations
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public String Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public String Longitude { get; set; }
    }
}
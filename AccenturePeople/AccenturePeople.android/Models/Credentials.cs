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
    class Credentials
    {
        [JsonProperty(PropertyName = "username")]
        public string UserName;

        [JsonProperty(PropertyName = "password")]
        public string Password;

        [JsonProperty(PropertyName = "is_remember")]
        public short IsRemember;
    }
}
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
    class Login
    {
        [JsonProperty(PropertyName = "access_token")]
        public String AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public String TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public String UserName { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public String Issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public String Expires { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace AccenturePeoplePCL.Models
{
    public class Login
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

        [JsonProperty(PropertyName = "error")]
        public String Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public String ErrorDescription { get; set; }
    }
}
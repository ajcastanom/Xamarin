using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace AccenturePeoplePCL.Models
{
    public class Wbs
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "code")]
        public String Code { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }
    }
}
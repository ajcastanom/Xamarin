using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace AccenturePeoplePCL.Models
{
    public class Locations
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
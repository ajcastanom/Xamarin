using System;

using Newtonsoft.Json;

namespace AccenturePeoplePCL.Models
{
    public class Project
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "descriotion")]
        public String Description { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccenturePeoplePCL.Models
{
    public class ContactService
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idAspNetUsers")]
        public string IdAspNetUsers { get; set; }

        [JsonProperty(PropertyName = "idContactLocations")]
        public int IdContactLocations { get; set; }

        [JsonProperty(PropertyName = "LocationName")]
        public string LocationName { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "idWbs")]
        public int IdWbs { get; set; }

        [JsonProperty(PropertyName = "Wbsname")]
        public string Wbsname { get; set; }

        [JsonProperty(PropertyName = "idProject")]
        public int IdProject { get; set; }

        [JsonProperty(PropertyName = "ProjectName")]
        public string ProjectName { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "userAcc")]
        public string UserAcc { get; set; }

        [JsonProperty(PropertyName = "idDocument")]
        public string IdDocument { get; set; }

        [JsonProperty(PropertyName = "professionalProfile")]
        public string ProfessionalProfile { get; set; }
    }
}

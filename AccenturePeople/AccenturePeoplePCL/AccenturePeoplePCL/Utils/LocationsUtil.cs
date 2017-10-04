using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccenturePeoplePCL.Models;

namespace AccenturePeoplePCL.Utils
{
    public class LocationsUtil
    {
        private Dictionary<string, long> locationsId;
        private List<Locations> locations;

        public LocationsUtil(List<Locations> _locations)
        {
            this.locationsId = new Dictionary<string, long>();
            this.locations = _locations;

            foreach (Locations location in _locations)
            {
                this.locationsId.Add(location.Name, location.Id);
            }
        }

        public long getId(string name)
        {
            return locationsId[name];
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
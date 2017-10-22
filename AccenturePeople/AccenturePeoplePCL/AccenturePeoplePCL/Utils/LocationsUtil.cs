using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccenturePeoplePCL.Models;

namespace AccenturePeoplePCL.Utils
{
    public class LocationsUtil
    {
        private static Dictionary<string, long> locationsId;
        private static List<Locations> locations;

        public LocationsUtil(List<Locations> _locations)
        {
            locationsId = new Dictionary<string, long>();
            locations = _locations;

            foreach (Locations location in _locations)
            {
                locationsId.Add(location.Name, location.Id);
            }
        }

        public static long getId(string name)
        {
            return locationsId[name];
        }

        public static List<String> getListNames()
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
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
        private static Dictionary<long, int> locationsIndex;
        private static List<Locations> locations;

        public LocationsUtil(List<Locations> _locations)
        {
            locationsId = new Dictionary<string, long>();
            locationsIndex = new Dictionary<long, int>();
            locations = _locations;
            int index = 0;

            foreach (Locations location in _locations)
            {
                locationsId.Add(location.Name, location.Id);
                locationsIndex.Add(location.Id, ++index);
            }
        }

        public static long getId(string name)
        {
            return locationsId[name];
        }

        public static int getIndex(long id)
        {
            return locationsIndex[id];
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
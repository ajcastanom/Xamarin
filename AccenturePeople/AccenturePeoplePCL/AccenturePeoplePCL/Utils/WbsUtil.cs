using AccenturePeoplePCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccenturePeoplePCL.Utils
{
    public class WbsUtil
    {
        private static Dictionary<string, long> WbsId;
        private static Dictionary<long, int> WbsIndex;
        private static List<Wbs> ListWbs;

        public WbsUtil(List<Wbs> _wbs)
        {
            WbsId = new Dictionary<string, long>();
            WbsIndex = new Dictionary<long, int>();
            ListWbs = _wbs;
            int index = 0;
            foreach (Wbs wbs in _wbs)
            {
                WbsId.Add(wbs.Name, wbs.Id);
                WbsIndex.Add(wbs.Id, ++index);
            }
        }

        public static long getId(string name)
        {
            return WbsId[name];
        }

        public static int getIndex(long id)
        {
            return WbsIndex[id];
        }

        public static List<String> getListNames()
        {
            List<string> listNames = new List<string>();
            foreach (Wbs project in ListWbs)
            {
                listNames.Add(project.Name);
            }

            return listNames;
        }
    }
}
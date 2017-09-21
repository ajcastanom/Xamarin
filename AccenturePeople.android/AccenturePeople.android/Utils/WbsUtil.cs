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
using Java.Util;
using AccenturePeople.android.Models;

namespace AccenturePeople.android.Utils
{
    class WbsUtil
    {
        private HashMap WbsId;
        private List<Wbs> ListWbs;

        public WbsUtil(List<Wbs> _wbs)
        {
            this.WbsId = new HashMap();
            this.ListWbs = _wbs;

            foreach (Wbs wbs in _wbs)
            {
                this.WbsId.Put(wbs.Name, wbs.Id);
            }
        }

        public long getId(string name)
        {
            return long.Parse(WbsId.Get(name).ToString());
        }

        public List<String> getListNames()
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
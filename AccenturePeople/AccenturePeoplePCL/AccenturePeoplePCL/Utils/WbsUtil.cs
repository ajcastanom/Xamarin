﻿using AccenturePeoplePCL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccenturePeoplePCL.Utils
{
    public class WbsUtil
    {
        private Dictionary<string, long> WbsId;
        private List<Wbs> ListWbs;

        public WbsUtil(List<Wbs> _wbs)
        {
            this.WbsId = new Dictionary<string, long>();
            this.ListWbs = _wbs;

            foreach (Wbs wbs in _wbs)
            {
                this.WbsId.Add(wbs.Name, wbs.Id);
            }
        }

        public long getId(string name)
        {
            return WbsId[name];
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
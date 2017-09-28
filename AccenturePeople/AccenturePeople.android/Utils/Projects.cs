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
    class Projects
    {
        private HashMap projectsId;
        private List<Project> projects;

        public Projects(List<Project> _projects)
        {
            this.projectsId = new HashMap();
            this.projects = _projects;

            foreach(Project project in _projects){
                this.projectsId.Put(project.Name, project.Id);
            }
        }

        public long getId(string name)
        {
            return long.Parse(projectsId.Get(name).ToString());
        }

        public List<String> getListNames()
        {
            List<string> listNames = new List<string>();
            foreach(Project project in projects)
            {
                listNames.Add(project.Name);
            }

            return listNames;
        }
    }
}
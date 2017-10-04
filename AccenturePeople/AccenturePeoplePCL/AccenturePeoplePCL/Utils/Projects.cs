using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccenturePeoplePCL.Models;

namespace AccenturePeoplePCL.Utils
{
    public class Projects
    {
        private Dictionary<string, long> projectsId;
        private List<Project> projects;

        public Projects(List<Project> _projects)
        {
            this.projectsId = new Dictionary<string, long>();
            this.projects = _projects;

            foreach(Project project in _projects){
                this.projectsId.Add(project.Name, project.Id);
            }
        }

        public long getId(string name)
        {
            return projectsId[name];
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
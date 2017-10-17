using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccenturePeoplePCL.Models;

namespace AccenturePeoplePCL.Utils
{
    public class Projects
    {
        private static Dictionary<string, long> projectsId;
        private static List<Project> projects;

        public Projects(List<Project> _projects)
        {
            projectsId = new Dictionary<string, long>();
            projects = _projects;

            foreach(Project project in _projects){
                projectsId.Add(project.Name, project.Id);
            }
        }

        public static long getId(string name)
        {
            return projectsId[name];
        }

        public static List<String> getListNames()
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
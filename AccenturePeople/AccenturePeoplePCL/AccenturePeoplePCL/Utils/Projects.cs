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
        private static Dictionary<long, int> projectsIndex;
        private static List<Project> projects;

        public Projects(List<Project> _projects)
        {
            projectsId = new Dictionary<string, long>();
            projectsIndex = new Dictionary<long, int>();
            projects = _projects;
            int index = 0;

            foreach(Project project in _projects){
                projectsId.Add(project.Name, project.Id);
                projectsIndex.Add(project.Id, ++index);
            }
        }

        public static long getId(string name)
        {
            return projectsId[name];
        }

        public static int getIndex(long id)
        {
            return projectsIndex[id];
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
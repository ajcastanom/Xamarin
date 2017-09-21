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
using System.Net.Http;
using AccenturePeople.android.Models;
using Newtonsoft.Json;

namespace AccenturePeople.android.RestServices
{
    class ContactRestService
    {
        private static string REST_URL = "http://contactaccenture.azurewebsites.net/";

        public static async System.Threading.Tasks.Task<List<Project>> GetProjects()
        {
            string UriUserInfo = "contactAcc/GetProjects";

            string url = REST_URL + UriUserInfo;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, new StringContent("application/json, text/json"));

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                List <Project> projects = JsonConvert.DeserializeObject<List<Project>>(content);

                //handling the answer  
                return projects;
            }
        }

        public static async System.Threading.Tasks.Task<List<Wbs>> GetWbs()
        {
            string UriUserInfo = "contactAcc/GetWbs";

            string url = REST_URL + UriUserInfo;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, new StringContent("application/json, text/json"));

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                List<Wbs> wbs = JsonConvert.DeserializeObject<List<Wbs>>(content);

                //handling the answer  
                return wbs;
            }
        }
    }
}
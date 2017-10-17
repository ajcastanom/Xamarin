using System.Collections.Generic;

using AccenturePeoplePCL.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;

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

        public static async System.Threading.Tasks.Task<List<Locations>> GetLocation()
        {
            string UriUserInfo = "contactAcc/GetLocations";

            string url = REST_URL + UriUserInfo;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, new StringContent("application/json, text/json"));

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                List<Locations> location = JsonConvert.DeserializeObject<List<Locations>>(content);

                //handling the answer  
                return location;
            }
        }

        public static async System.Threading.Tasks.Task<String> InsertContactUserAsync(Contact contact)
        {
            string Uri = "contactAcc/InsertContactUser";

            string url = REST_URL + Uri;

            //url += "?UserName=" + Username + "&Password=" + Password + "&grant_type=password";

            using (var client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod("POST"), url);
                message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                List<KeyValuePair<string, string>> nameValueCollection = new List<KeyValuePair<string, string>>();
                nameValueCollection.Add(new KeyValuePair<string, string>("idContactLocations", contact.Location));
                nameValueCollection.Add(new KeyValuePair<string, string>("idWbs", contact.Wbs));
                nameValueCollection.Add(new KeyValuePair<string, string>("idProject", contact.Project));
                nameValueCollection.Add(new KeyValuePair<string, string>("firstName", contact.Firstname));
                nameValueCollection.Add(new KeyValuePair<string, string>("lastName", contact.LastName));
                var username = contact.Email.Split('@')[0];
                nameValueCollection.Add(new KeyValuePair<string, string>("userAcc", username));
                nameValueCollection.Add(new KeyValuePair<string, string>("idDocument", contact.Identification.ToString()));
                nameValueCollection.Add(new KeyValuePair<string, string>("professionalProfile", contact.ProfessionalProfile));
                nameValueCollection.Add(new KeyValuePair<string, string>("idWbs", contact.Wbs));
                message.Content = new FormUrlEncodedContent(nameValueCollection);

                String msg = null;
                try
                {
                    HttpResponseMessage httpResponseMessage = await client.SendAsync(message);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    HttpContent httpContent = httpResponseMessage.Content;
                    var content = await httpContent.ReadAsStringAsync();

                    String response = JsonConvert.DeserializeObject<String>(content);

                    msg = response;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("400 (Bad Request)"))
                    {
                        msg = "El usuario ya existe, ingrese otro diferente.";
                    }
                    else
                    {
                        msg = "Error al registrar el usuario";
                    }

                }

                return msg;
            }

        }
    }


}
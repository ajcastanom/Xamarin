using System;
using FSharpUtils.Newtonsoft;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using AccenturePeoplePCL.Models;
using System.Net.Http.Headers;

namespace AccenturePeople.android.RestServices
{
    static class AccountRestService
    {
        private static string REST_URL = "http://contactaccenture.azurewebsites.net/";

        public static async System.Threading.Tasks.Task<Login> LoginAsync(String Username, String Password)
        {
            string UriToken = "token";

            string url = REST_URL + UriToken;

            //url += "?UserName=" + Username + "&Password=" + Password + "&grant_type=password";

            using (var client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod("POST"), url);
                message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                List<KeyValuePair<string, string>> nameValueCollection = new List<KeyValuePair<string, string>>();
                nameValueCollection.Add(new KeyValuePair<string, string>("UserName", Username));
                nameValueCollection.Add(new KeyValuePair<string, string>("Password", Password));
                nameValueCollection.Add(new KeyValuePair<string, string>("grant_type", "password"));
                message.Content = new FormUrlEncodedContent(nameValueCollection);

                try
                {
                    HttpResponseMessage httpResponseMessage = await client.SendAsync(message);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    HttpContent httpContent = httpResponseMessage.Content;
                    var content = await httpContent.ReadAsStringAsync();
                    
                    Login login = JsonConvert.DeserializeObject<Login>(content);

                    //handling the answer  
                    return login;
                }
                catch (Exception ex)
                {
                    Login login = new Login();
                    login.Error = "true";

                    return login;
                }               
            }

        }

        public static async System.Threading.Tasks.Task<String> GetUserInfoAsync()
        {
            string UriUserInfo = "api/Account/UserInfo";

            string url = REST_URL + UriUserInfo;

            using (var client = new HttpClient())
            {
                // send a GET request  
                var uri = "http://jsonplaceholder.typicode.com/posts";
                var result = await client.GetStringAsync(uri);

                var list = JsonConvert.DeserializeObject<List<dynamic>>(result);

                //handling the answer  
                return result;
            }
        }
    }
}
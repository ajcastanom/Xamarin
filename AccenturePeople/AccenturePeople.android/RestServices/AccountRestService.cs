using System;
using FSharpUtils.Newtonsoft;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;
using AccenturePeople.android.Models;

namespace AccenturePeople.android.RestServices
{
    static class AccountRestService
    {
        private static string REST_URL = "http://contactaccenture.azurewebsites.net/";

        public static async System.Threading.Tasks.Task<Login> LoginAsync(String Username, String Password)
        {
            string UriToken = "token";

            string url = REST_URL + UriToken;

            url += "?UserName=" + Username + "&Password=" + Password + "&grant_type=password";

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, new StringContent("application/json, text/json"));

                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                Login login = JsonConvert.DeserializeObject<Login>(content);

                //handling the answer  
                return login;
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
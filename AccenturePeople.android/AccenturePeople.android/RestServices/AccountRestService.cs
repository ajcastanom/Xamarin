using System;
using FSharpUtils.Newtonsoft;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Linq;

namespace AccenturePeople.android.RestServices
{
    static class AccountRestService
    {
        private static string REST_URL = "http://contactaccenture.azurewebsites.net/";

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
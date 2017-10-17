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
            string Uri = "token";

            string url = REST_URL + Uri;

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

        public static async System.Threading.Tasks.Task<String> RegisterEmailAsync(String Username, String Password, String ConfirmPassword)
        {
            string Uri = "api/Account/Register";

            string url = REST_URL + Uri;

            //url += "?UserName=" + Username + "&Password=" + Password + "&grant_type=password";

            using (var client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod("POST"), url);
                message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                List<KeyValuePair<string, string>> nameValueCollection = new List<KeyValuePair<string, string>>();
                nameValueCollection.Add(new KeyValuePair<string, string>("Email", Username));
                nameValueCollection.Add(new KeyValuePair<string, string>("Password", Password));
                nameValueCollection.Add(new KeyValuePair<string, string>("ConfirmPassword", ConfirmPassword)); 
                message.Content = new FormUrlEncodedContent(nameValueCollection);

                String msg = null;
                try
                {
                    HttpResponseMessage httpResponseMessage = await client.SendAsync(message);
                    httpResponseMessage.EnsureSuccessStatusCode();
                    HttpContent httpContent = httpResponseMessage.Content;
                    var content = await httpContent.ReadAsStringAsync();

                    String response = JsonConvert.DeserializeObject<String>(content);

                    msg = null;
                }
                catch (Exception ex)
                {
                    if(ex.Message.Equals("400 (Bad Request)"))
                    {
                        msg = "El usuario ya existe, ingrese otro diferente.";
                    } else
                    {
                       msg = "Error al registrar el Email";
                    }
                    
                }

                return msg;
            }

        }

        public static async System.Threading.Tasks.Task<String> GetUserInfoAsync()
        {
            string Uri = "api/Account/UserInfo";

            string url = REST_URL + Uri;

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
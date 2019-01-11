using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace PetPlayMobile.Services
{
    public abstract class ApiService
    {
        protected const string URL = "http://00a4c486.ngrok.io/api/";

        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            if (App.Current.Properties.ContainsKey(App.JWT))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Current.Properties[App.JWT].ToString());
            }

            return client;
        }

        protected HttpContent GetHttpContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        protected T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);
    }
}

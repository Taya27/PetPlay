using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace PetPlayMobile.Services
{
    public abstract class ApiService
    {
        protected const string URL = "http://192.168.0.100:45455/api/";

        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PetPlayMobile.Models;

namespace PetPlayMobile.Services
{
    public class AuthService : ApiService
    {
        private readonly string _authUrl;

        public AuthService()
        {
            _authUrl += URL + "auth";
        }

        public async Task<LoginResultModel> Login(LoginModel model)
        {
            var client = GetClient();
            var content = GetHttpContent(model);

            var response = await client.PostAsync(_authUrl + "/login", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                throw new Exception(result);
            }

            return Deserialize<LoginResultModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
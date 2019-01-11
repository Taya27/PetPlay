using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(result);
            }

            return Deserialize<LoginResultModel>(result);
        }

        public async Task<string> Register(SignUpModel model)
        {
            var client = GetClient();
            var content = GetHttpContent(model);

            var response = await client.PostAsync(_authUrl + "/register", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                throw new Exception(result);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}

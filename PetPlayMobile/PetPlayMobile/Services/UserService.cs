using System;
using System.Threading.Tasks;
using PetPlayMobile.Models;

namespace PetPlayMobile.Services
{
    public class UserService : ApiService
    {
        private readonly string _Url;

        public UserService()
        {
            _Url += URL + "users/";
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            var client = GetClient();

            var response = await client.GetStringAsync(_Url + $"get-user/{id}");

            return Deserialize<UserModel>(response);
        }
    }
}
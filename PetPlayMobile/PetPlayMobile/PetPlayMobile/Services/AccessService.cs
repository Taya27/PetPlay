using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;

namespace PetPlayMobile.Services
{
    public class AccessService : ApiService
    {
        private readonly string _Url;
        public AccessService()
        {
            _Url += URL + "accesses/";
        }

        public async Task<IEnumerable<AccessModel>> GetUserAccesses(string id)
        {
            var client = GetClient();

            var result = await client.GetStringAsync(_Url + $"get-user-accesses/{id}");

            return Deserialize<IEnumerable<AccessModel>>(result);
        }

        public async Task<string> AddAccess(AddNewToyModel model)
        {
            var client = GetClient();
            var content = GetHttpContent(model);

            var response = await client.PostAsync(_Url + "add-access", content);
            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(result);
            }

            return result;
        }
    }
}

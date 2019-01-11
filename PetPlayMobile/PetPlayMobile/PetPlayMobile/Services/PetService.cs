using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayMobile.Models;

namespace PetPlayMobile.Services
{
    public class PetService : ApiService
    {
        private readonly string _Url;

        public PetService()
        {
            _Url += URL + "pets/";
        }

        public async Task<IEnumerable<PetModel>> GetUserPets(string userId)
        {
            var client = GetClient();

            var response = await client.GetAsync(_Url + $"get-user-pets/{userId}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(result);
            }

            return Deserialize<IEnumerable<PetModel>>(result);
        }

        public async Task<PetModel> AddNewPet(AddPetModel model)
        {
            var client = GetClient();
            var content = GetHttpContent(model);

            var response = await client.PostAsync(_Url + "add-pet", content);
            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(result);
            }

            return Deserialize<PetModel>(result);
        }

        public async Task<PetModel> DeletePet(Guid id)
        {
            var client = GetClient();

            var response = await client.DeleteAsync($"{_Url}delete-pet/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(result);
            }

            return Deserialize<PetModel>(result);
        }
    }
}

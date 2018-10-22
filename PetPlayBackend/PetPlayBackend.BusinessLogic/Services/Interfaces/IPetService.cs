using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPets();

        Task<Pet> AddNewPet(AddNewPetViewModel model);
    }
}

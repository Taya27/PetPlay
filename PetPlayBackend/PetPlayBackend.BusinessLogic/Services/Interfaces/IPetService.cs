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
        Task<IEnumerable<PetModel>> GetAllPets();

        Task<PetModel> AddNewPet(AddNewPetViewModel model);

        Task<PetModel> DeletePet(Guid id);
    }
}

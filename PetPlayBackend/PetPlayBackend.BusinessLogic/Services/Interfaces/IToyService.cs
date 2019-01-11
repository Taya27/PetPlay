using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.ViewModels;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IToyService
    {
        Task<ToyModel> AddNewToy(ToyViewModel model, string url);

        Task<IEnumerable<ToyModel>> GetAllToys();

        Task DeleteAllToys();
    }
}

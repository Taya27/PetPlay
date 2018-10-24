using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayBackend.BusinessLogic.ViewModels;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IToyService
    {
        Task AddNewToy(ToyViewModel model);
    }
}

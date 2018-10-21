using PetPlayBackend.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(RegistrationViewModel model);

        Task<UserViewModel> FindUser(LoginViewModel model);
    }
}

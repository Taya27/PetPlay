using PetPlayBackend.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetPlayBackend.Services.Interfaces
{
    public interface IUserService
    {
        LoginViewModel FindUser(LoginViewModel model);

        RegisterViewModel RegisterUser(RegisterViewModel model);
    }
}

using PetPlayBackend.Common.Helpers;
using PetPlayBackend.Common.ViewModels;
using PetPlayBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetPlayBackend.Services
{
    public class UserService : IUserService
    {
        public LoginViewModel FindUser(LoginViewModel model)
        {
            try
            {
                var passHash = AccountHelper.GetPasswordHash(model.Password);

                // Mock user from database
                var result = new LoginViewModel
                {
                    Login = model.Login,
                    Password = model.Password
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RegisterViewModel RegisterUser(RegisterViewModel model)
        {
            try
            {
                // Here will be registration process

                return new RegisterViewModel
                {
                    Email = model.Email,
                    Nickname = model.Nickname,
                    Password = model.Password
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

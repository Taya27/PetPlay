using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetPlayBackend.BusinessLogic.Common.Helpers;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.BusinessLogic.ViewModels;
using PetPlayBackend.Domain.Contexts;
using PetPlayBackend.Domain.Models;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task RegisterUser(RegistrationViewModel model)
        {
            try
            {
                var incorrectEmailOrUserName = await _context.Users
                    .AnyAsync(x => x.Email == model.Email || x.Nickname == model.Nickname);

                if (incorrectEmailOrUserName)
                {
                    throw new Exception("User already exists!   ");
                }

                var userModel = _mapper.Map<User>(model);

                userModel.Password = AccountHelper.GetPasswordHash(model.Password);

                _context.Users.Add(userModel);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserViewModel> FindUser(LoginViewModel model)
        {
            try
            {
                var passHash = AccountHelper.GetPasswordHash(model.Password);

                var result = await _context.Users.FirstOrDefaultAsync(u =>
                    ((u.Email == model.Login || u.Nickname == model.Login) && u.Password == passHash));

                if (result == null)
                {
                    throw new Exception("Invalid login or password");
                }

                return _mapper.Map<UserViewModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

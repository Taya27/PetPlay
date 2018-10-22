using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetPlayBackend.BusinessLogic.Common.Helpers;
using PetPlayBackend.BusinessLogic.Models;
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

                var userModel = _mapper.Map<Domain.Models.User>(model);

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

        public async Task<IEnumerable<Models.User>> GetAllUsers()
        {
            try
            {
                var result = _context.Users.Include(x => x.Pets).Select(x => _mapper.Map<Models.User>(x));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Models.User> GetUser(Guid id)
        {
            try
            {
                var result = await _context.Users.Include(x => x.Pets).FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                {
                    throw new Exception("User not found!");
                }

                return _mapper.Map<Models.User>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

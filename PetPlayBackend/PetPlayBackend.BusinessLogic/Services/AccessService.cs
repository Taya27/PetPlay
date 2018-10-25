using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.BusinessLogic.ViewModels;
using PetPlayBackend.Domain.Contexts;
using PetPlayBackend.Domain.Models;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class AccessService : IAccessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccessService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddNewToyAccess(AccessViewModel model)
        {
            try
            {
                //var alreadyOwned =
                //    await _context.Accesses
                //        .FirstOrDefaultAsync(x => x.ToyId == model.ToyId && x.IsOwner == model.IsOwner);

                //if (alreadyOwned != null)
                //{
                //    throw new Exception("This toy is already owned by someone");
                //} FAILS WHEN GIVING ACCESS TO SECOND FRIEND

                await _context.Accesses.AddAsync(_mapper.Map<Access>(model));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccessModel>> GetUsersAccessesById(Guid userId)
        {
            try
            {
                var result = await _context.Accesses
                    .Include(x => x.Toy)
                    .Include(x => x.User)
                    .Where(x => x.UserId == userId)
                    .Select(x => _mapper.Map<AccessModel>(x))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<GrantedToyViewModel>> GetUserGrantedToys(Guid userId)
        {
            try
            {
                var result = await _context.Accesses
                    .Include(x => x.Toy)
                    .Where(x => x.UserId == userId && !x.IsOwner)
                    .ToListAsync();

                var res = await _context.Accesses
                    .Include(x => x.User)
                    .Where(x => x.IsOwner)
                    .ToListAsync();


                return res.Join(
                    result,
                    x => x.ToyId,
                    y => y.ToyId,
                    (a, b) => new GrantedToyViewModel
                        {
                            User = _mapper.Map<UserModel>(a.User),
                            Toy = _mapper.Map<ToyModel>(b.Toy)
                        }
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccessModel> GetAccessByUserIdAndToyId(Guid userId, Guid toyId)
        {
            try
            {
                var result = await _context.Accesses
                    .Include(x => x.Toy)
                    .FirstOrDefaultAsync(x => x.ToyId == toyId && x.UserId == userId);

                return _mapper.Map<AccessModel>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

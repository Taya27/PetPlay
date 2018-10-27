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
                var alreadyOwned =
                    await _context.Accesses.AnyAsync(x => x.ToyId == model.ToyId && 
                                                          x.IsOwner && 
                                                          model.IsOwner);

                if (alreadyOwned)
                {
                    throw new Exception("This toy is already owned by someone");
                }

                var alreadyGrantedAccess =
                    await _context.Accesses.AnyAsync(x => x.ToyId == model.ToyId &&
                                                          x.UserId == model.UserId);

                if (alreadyGrantedAccess)
                {
                    throw new Exception("Access to this toy is already granted to this user");
                }

                var isToyIdInvalid = await _context.Toys.FirstOrDefaultAsync(x => x.Id == model.ToyId) == null;

                if (isToyIdInvalid)
                {
                    throw new Exception("This toy does not exist. Check your id or contact us");
                }

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
                var userAccesses = await _context.Accesses
                    .Include(x => x.Toy)
                    .Where(x => x.UserId == userId && !x.IsOwner)
                    .ToListAsync();

                var ownerAccesses = await _context.Accesses
                    .Include(x => x.User)
                    .Where(x => x.IsOwner)
                    .ToListAsync();

                return ownerAccesses.Join(
                    userAccesses,
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

        public async Task<IEnumerable<GrantedToyViewModel>> GetUserToyGrants(Guid userId)
        {
            try
            {
                var userOwnToys = await _context.Accesses
                    .Where(x => x.UserId == userId && x.IsOwner)
                    .ToListAsync();

                var userAccesses = await _context.Accesses
                    .Include(x => x.Toy)
                    .Where(x => x.UserId == userId && x.IsOwner)
                    .ToListAsync();

                var ownerAccesses = await _context.Accesses
                    .Include(x => x.User)
                    .Where(x => !x.IsOwner)
                    .ToListAsync();

                return ownerAccesses.Join(
                    userAccesses,
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

        public async Task DeleteAccessByUserIdAndToyId(Guid userId, Guid toyId)
        {
            try
            {
                var foundAccess = await _context.Accesses
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.ToyId == toyId);

                if (foundAccess == null)
                {
                    throw new Exception("Access not found");
                }

                _context.Accesses.Remove(foundAccess);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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

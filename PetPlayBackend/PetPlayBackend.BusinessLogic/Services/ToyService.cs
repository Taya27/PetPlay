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
    public class ToyService : IToyService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ToyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddNewToy(ToyViewModel model)
        {
            try
            {
                await _context.Toys.AddAsync(_mapper.Map<Toy>(model));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ToyModel>> GetAllToys()
        {
            try
            {
                var result = await _context.Toys.ToListAsync();

                return result.Select(x => _mapper.Map<ToyModel>(x));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

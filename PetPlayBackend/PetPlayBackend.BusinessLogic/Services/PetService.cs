using AutoMapper;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.BusinessLogic.ViewModels;
using PetPlayBackend.Domain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class PetService : IPetService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public PetService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAllPets()
        {
            try
            {
                var pets = _context.Pets.Select(x => _mapper.Map<Pet>(x));

                return pets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pet> AddNewPet(AddNewPetViewModel model)
        {
            try
            {
                var dbModel = _mapper.Map<Domain.Models.Pet>(model);

                await _context.Pets.AddAsync(dbModel);

                await _context.SaveChangesAsync();

                return _mapper.Map<Models.Pet>(dbModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PetModel>> GetAllPets()
        {
            try
            {
                var pets = _context.Pets.Select(x => _mapper.Map<PetModel>(x));

                return pets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetModel> AddNewPet(AddNewPetViewModel model)
        {
            try
            {
                var dbModel = _mapper.Map<Domain.Models.Pet>(model);

                await _context.Pets.AddAsync(dbModel);

                await _context.SaveChangesAsync();

                return _mapper.Map<Models.PetModel>(dbModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetModel> DeletePet(Guid id)
        {
            try
            {
                var petToDelete = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);

                if (petToDelete == null)
                {
                    throw new Exception("Pet not found");
                }

                _context.Pets.Remove(petToDelete);
                await _context.SaveChangesAsync();

                return _mapper.Map<Models.PetModel>(petToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

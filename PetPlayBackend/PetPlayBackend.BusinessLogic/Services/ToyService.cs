using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.Domain.Contexts;

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

        public async Task<ToyModel> AddNewToy()
        {
            throw new NotImplementedException();
        }
    }
}

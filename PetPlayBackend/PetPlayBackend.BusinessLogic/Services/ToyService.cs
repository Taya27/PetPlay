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

        public async Task<ToyModel> AddNewToy(ToyViewModel model, string url)
        {
            try
            {
                var map = _mapper.Map<Toy>(model);
                await _context.Toys.AddAsync(map);
                await _context.SaveChangesAsync();

                map.QRUrl = $"{url}/{map.Id}.jpeg";
                await _context.SaveChangesAsync();

                return _mapper.Map<ToyModel>(map);
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
                var toys = await _context.Toys.ToListAsync();
                var map = new List<ToyModel>();

                foreach (var toy in toys)
                {
                    map.Add(new ToyModel
                    {
                        Id = toy.Id,
                        Model = toy.Model,
                        QRUrl = toy.QRUrl,
                        IsOwnedBySomeone = _context.Accesses.Any(x => x.ToyId == toy.Id && x.IsOwner),
                    });
                }

                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAllToys()
        {
            try
            {
                _context.Toys.RemoveRange(_context.Toys);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

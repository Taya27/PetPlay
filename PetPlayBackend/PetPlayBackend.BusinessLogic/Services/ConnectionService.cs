using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.Domain.Contexts;
using PetPlayBackend.Domain.Models;

namespace PetPlayBackend.BusinessLogic.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConnectionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConnectionModel> AddConnection(ConnectionModel model)
        {
            try
            {
                var isUserAlredyConnected =
                    await _context.Connections.AnyAsync(x => x.UserId == model.UserId && x.EndTime == null);

                if (isUserAlredyConnected)
                {
                    throw new Exception("You are already connected to another toy. Please disconnect first and then try again");
                }

                var isToyAlreadyConnected =
                    await _context.Connections.AnyAsync(x => x.ToyId == model.ToyId && x.EndTime == null);

                if (isToyAlreadyConnected)
                {
                    throw new Exception("This toy is already controlled by someone. Please try again later");
                }

                var dbModel = _mapper.Map<Connection>(model);
                dbModel.StartTime = DateTime.Now;

                await _context.Connections.AddAsync(dbModel);
                await _context.SaveChangesAsync();

                return _mapper.Map<ConnectionModel>(dbModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ConnectionModel> GetCurrentUserConnection(Guid userId)
        {
            try
            {
                var userConnection = await _context.Connections
                    .Include(x => x.Toy)
                    .FirstOrDefaultAsync(x => x.UserId == userId && x.EndTime == null);

                if (userConnection == null)
                {
                    throw new Exception("You are currently not connected. But you can do this in your account profile");
                }

                return _mapper.Map<ConnectionModel>(userConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Disconnect(Guid toyId)
        {
            try
            {
                var toy = await _context.Connections.FirstOrDefaultAsync(x => x.ToyId == toyId && x.EndTime == null);

                if (toy == null)
                {
                    throw new Exception("Connection not found");
                }

                toy.EndTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

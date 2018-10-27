using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayBackend.BusinessLogic.Models;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IConnectionService
    {
        Task<ConnectionModel> AddConnection(ConnectionModel model);

        Task<ConnectionModel> GetCurrentUserConnection(Guid userId);

        Task Disconnect(Guid toyId);
    }
}

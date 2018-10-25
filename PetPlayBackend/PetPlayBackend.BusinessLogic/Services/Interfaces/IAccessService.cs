using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.ViewModels;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IAccessService
    {
        Task AddNewToyAccess(AccessViewModel model);

        Task<IEnumerable<AccessModel>> GetUsersAccessesById(Guid userId);

        Task<AccessModel> GetAccessByUserIdAndToyId(Guid userId, Guid toyId);

        Task<IEnumerable<GrantedToyViewModel>> GetUserGrantedToys(Guid userId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface ITokenService
    {
        String BuildToken(Guid id);
    }
}

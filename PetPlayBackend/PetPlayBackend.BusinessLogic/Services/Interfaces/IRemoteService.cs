using System;
using System.Collections.Generic;
using System.Text;
using PetPlayBackend.BusinessLogic.Common;

namespace PetPlayBackend.BusinessLogic.Services.Interfaces
{
    public interface IRemoteService
    {
        void SetLedState(Led led, LedState state);
        void TurnOnRing(byte quantity);
    }
}

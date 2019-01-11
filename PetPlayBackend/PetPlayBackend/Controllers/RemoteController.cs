using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetPlayBackend.BusinessLogic.Common;
using PetPlayBackend.BusinessLogic.Services.Interfaces;

namespace PetPlayBackend.Controllers
{
    [Route("api/remote")]
    [ApiController]
    public class RemoteController : ControllerBase
    {
        private readonly IRemoteService _remoteService;

        public RemoteController(IRemoteService remoteService)
        {
            _remoteService = remoteService;
        }

        [HttpPost("set-state")]
        public async Task SetState([FromBody] LedQueryInfo info)
        {
            _remoteService.SetLedState((Led)info.Led, (LedState)info.State);
        }

        [HttpPost("turn-on-ring")]
        public async Task TurnOnRing([FromBody]byte quantity)
        {
            _remoteService.TurnOnRing(quantity);
        }
    }

    public class LedQueryInfo
    {
        public int Led { get; set; }
        public int State { get; set; }
    }
}
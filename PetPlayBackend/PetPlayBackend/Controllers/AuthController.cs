using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetPlayBackend.BusinessLogic.Models;
using PetPlayBackend.BusinessLogic.Services.Interfaces;
using PetPlayBackend.BusinessLogic.ViewModels;

namespace PetPlayBackend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                await _userService.RegisterUser(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Succesfully registered user");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserViewModel result = null;
            try
            {
                result = await _userService.FindUser(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var jwtToken = _tokenService.BuildToken(result.Id);

            return Ok(jwtToken);
        }
    }
}
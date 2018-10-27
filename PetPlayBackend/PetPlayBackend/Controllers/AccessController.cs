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
    [Route("api/accesses")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;

        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }

        [HttpPost("add-access")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAccess([FromBody] AccessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accessService.AddNewToyAccess(model);

                return Ok("Access was granted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-accesses/{userId}")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(IEnumerable<AccessModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsersAccessesById(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accessService.GetUsersAccessesById(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-granted-toys/{userId}")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(IEnumerable<GrantedToyViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserGrantedToys(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accessService.GetUserGrantedToys(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-toy-grants/{userId}")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(IEnumerable<GrantedToyViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserToyGrants(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accessService.GetUserToyGrants(userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-access-by-user-id-and-toy-id/{userId}/{toyId}")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(AccessModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccessByUserIdAndToyId(Guid userId, Guid toyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _accessService.GetAccessByUserIdAndToyId(userId, toyId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-access-by-user-id-and-toy-id/{userId}/{toyId}")]
        [AllowAnonymous] // CHANGE
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccessByUserIdAndToyId(Guid userId, Guid toyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accessService.DeleteAccessByUserIdAndToyId(userId, toyId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
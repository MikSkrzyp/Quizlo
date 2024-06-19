using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Quizlo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthentificationController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        // POST: api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Register([FromBody] UserDto userDTO)
        {
            try
            {
                var errors = await _authManager.Register(userDTO);

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your register request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        // POST: api/Account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDTO)
        {
            try
            {
                var authResponse = await _authManager.Login(loginDTO);

                if (authResponse == null)
                {
                    return Unauthorized();
                }

                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your login request."
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}

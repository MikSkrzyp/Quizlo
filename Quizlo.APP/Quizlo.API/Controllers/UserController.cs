using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizlo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly QuizloDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(QuizloDbContext dbContext, IMapper mapper, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("ReadAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var usersDomain = await userRepository.GetAllAsync();
                return Ok(mapper.Map<List<GetUserDTO>>(usersDomain));
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get all users request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("ReadOneUser/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var userDomain = await userRepository.GetByIdAsync(id);
                if (userDomain == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<GetUserDTO>(userDomain));
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get user by id request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete("DeleteOneUser/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var userDomain = await userRepository.DeleteAsync(id);
                if (userDomain == null)
                {
                    return NotFound();
                }
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your delete user request."
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;

namespace Quizlo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly QuizloDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(QuizloDbContext dbContext,IMapper mapper,IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usersDomain = await userRepository.GetAllAsync();
            //throw new Exception("blad");
            return Ok(mapper.Map<List<GetUserDTO>>(usersDomain));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var userDomain = await userRepository.GetByIdAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GetUserDTO>(userDomain));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var userDomain = await userRepository.DeleteAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }
            return Ok("Deleted");
        }
    }
}

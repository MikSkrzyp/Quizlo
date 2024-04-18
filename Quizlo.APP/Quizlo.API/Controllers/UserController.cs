using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
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
            return Ok(mapper.Map<List<User>>(usersDomain));
        }
    }
}

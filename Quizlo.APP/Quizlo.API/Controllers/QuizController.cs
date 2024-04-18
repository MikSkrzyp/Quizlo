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
    public class QuizController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly QuizloDbContext dbContext;
        private readonly IQuizRepository quizRepository;

        public QuizController(IMapper mapper, QuizloDbContext dbContext,IQuizRepository quizRepository)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.quizRepository = quizRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuizDto createQuizDto)
        {
            var quizDomain = mapper.Map<Quiz>(createQuizDto);
            await quizRepository.CreateAsync(quizDomain);
            return Ok(quizDomain.QuizID);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quizDomain = await quizRepository.GetAllAsync();
            return Ok(mapper.Map<List<GetQuizDTO>>(quizDomain));
        }


    }
}

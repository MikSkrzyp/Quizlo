using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
        [Route("CreateOneQuiz")]
        public async Task<IActionResult> Create([FromBody] CreateQuizDto createQuizDto)
        {
            // //get currenr user id
            // var userId = User.FindFirstValue("uid");
            // createQuizDto.CreatorID = userId;

            var quizDomain = mapper.Map<Quiz>(createQuizDto);
            quizDomain.DateCreated = DateTime.Now;
            quizDomain.CreatorID = User.FindFirstValue("uid");
            await quizRepository.CreateAsync(quizDomain);
            return Ok(quizDomain.QuizID);
        }

        [HttpGet]
        [Route("ReadAllQuizzes")]
        public async Task<IActionResult> GetAll()
        {
            var quizDomain = await quizRepository.GetAllAsync();
            return Ok(mapper.Map<List<GetQuizDTO>>(quizDomain));
        }

        [HttpGet]
        [Route("ReadOneQuiz/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var quizDomain = await quizRepository.GetByIdAsync(id);
            if (quizDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GetQuizDTO>(quizDomain));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("UpdateOneQuiz/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateQuizDTO updateQuizDTO)
        {
            var quizDomain = mapper.Map<Quiz>(updateQuizDTO);

            quizDomain = await quizRepository.UpadteAsync(id, quizDomain);
            if (quizDomain == null)
            {
                return NotFound();
            }
            return Ok("Updated");
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteOneQuiz/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var quizDomain = await quizRepository.DeleteAsync(id);
            if (quizDomain == null)
            {
                return NotFound();
            }
            return Ok("Deleted");
        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quizlo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly QuizloDbContext dbContext;
        private readonly IQuizRepository quizRepository;

        public QuizController(IMapper mapper, QuizloDbContext dbContext, IQuizRepository quizRepository)
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
            try
            {
                var quizDomain = mapper.Map<Quiz>(createQuizDto);
                quizDomain.DateCreated = DateTime.Now;
                quizDomain.CreatorID = User.FindFirstValue("uid");
                await quizRepository.CreateAsync(quizDomain);
                return Ok(quizDomain.QuizID);
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your create quiz request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet]
        [Route("ReadAllQuizzes")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var quizDomain = await quizRepository.GetAllAsync();
                return Ok(mapper.Map<List<GetQuizDTO>>(quizDomain));
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get all quizes request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet]
        [Route("ReadOneQuiz/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var quizDomain = await quizRepository.GetByIdAsync(id);
                if (quizDomain == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<GetQuizDTO>(quizDomain));
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get quiz by id request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("UpdateOneQuiz/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateQuizDTO updateQuizDTO)
        {
            try
            {
                var quizDomain = mapper.Map<Quiz>(updateQuizDTO);

                quizDomain = await quizRepository.UpadteAsync(id, quizDomain);
                if (quizDomain == null)
                {
                    return NotFound();
                }
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your update quiz request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteOneQuiz/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var quizDomain = await quizRepository.DeleteAsync(id);
                if (quizDomain == null)
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
                    message = "An error occurred while processing your delete quiz request."
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}

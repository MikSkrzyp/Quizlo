using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quizlo.API.Model.Domain;
using Quizlo.API.Model.DTOs;
using Quizlo.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Quizlo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostQuestion([FromBody] QuestionDTO questionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Mapping DTO to Entity
                var question = new Question
                {
                    QuizID = questionDTO.QuizID,
                    QuestionText = questionDTO.QuestionText,
                    QuestionType = questionDTO.QuestionType,
                };

                foreach (var answerDto in questionDTO.Answers)
                {
                    question.Answers.Add(new Answer
                    {
                        AnswerText = answerDto.AnswerText,
                        IsCorrect = answerDto.IsCorrect
                    });
                }

                // Add question to repository
                await _questionRepository.AddQuestionAsync(question);

                return CreatedAtAction(nameof(GetQuestion), new { id = question.QuestionID }, question);
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your post question request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            try
            {
                var question = await _questionRepository.GetQuestionByIdAsync(id);

                if (question == null)
                {
                    return NotFound();
                }

                return question;
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get question request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpGet("quiz/{quizId}/Question/GetAllQuestionsById")]
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestionsByQuizId(int quizId)
        {
            try
            {
                var questions = await _questionRepository.GetAllQuestionsByQuizIdAsync(quizId);

                if (questions == null || !questions.Any())
                {
                    return NotFound();
                }

                return Ok(questions);
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your get all questions by id request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            try
            {
                var questionToDelete = await _questionRepository.GetQuestionByIdAsync(id);

                if (questionToDelete == null)
                {
                    return NotFound();
                }

                await _questionRepository.DeleteQuestionAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your delete question request."
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutQuestion(int id, [FromBody] QuestionDTO questionDTO)
        {
            try
            {
                var questionToUpdate = await _questionRepository.GetQuestionByIdAsync(id);

                if (questionToUpdate == null)
                {
                    return NotFound();
                }

                // Update question properties
                questionToUpdate.QuestionText = questionDTO.QuestionText;
                questionToUpdate.QuestionType = questionDTO.QuestionType;

                // Delete all existing answers
                questionToUpdate.Answers.Clear();

                // Add new answers
                foreach (var answerDto in questionDTO.Answers)
                {
                    questionToUpdate.Answers.Add(new Answer
                    {
                        AnswerText = answerDto.AnswerText,
                        IsCorrect = answerDto.IsCorrect
                    });
                }

                // Update question in repository
                await _questionRepository.UpdateQuestionAsync(questionToUpdate);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception here if necessary
                var errorResponse = new
                {
                    code = "500",
                    message = "An error occurred while processing your update question request."
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}

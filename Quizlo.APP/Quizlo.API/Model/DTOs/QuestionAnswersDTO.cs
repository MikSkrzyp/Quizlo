using Microsoft.AspNetCore.Http.HttpResults;
using Quizlo.API.Model.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Quizlo.API.Model.DTOs
{
    public class QuestionAnswersDTO
    {
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }

    public class AnswerDTO
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}

/*{
    "QuestionText": "What is the capital of France?",
  "QuestionType": "Multiple Choice",
  "Answers": [
    {
        "AnswerText": "Paris",
      "IsCorrect": true
    },
    {
        "AnswerText": "London",
      "IsCorrect": false
    },
    {
        "AnswerText": "Berlin",
      "IsCorrect": false
    },
    {
        "AnswerText": "Rome",
      "IsCorrect": false
    }
  ]
}*/

/*create Quiz POST
api/Quiz/{quizId}/ createQuestion

update question+answers PUT
api/Quiz/{quizId}/ Question /{ questionId}

delete question+answers DELETE
api/Quiz/{quizId}/ Question /{ questionId}

get question+answers GET
api/Quiz/{quizId}/ Question /{ questionId}*/

/*get all questions for given quiz using Pagination
question + answers GET
api/Quiz/{quizId}/ Question / getAllQuestions*/


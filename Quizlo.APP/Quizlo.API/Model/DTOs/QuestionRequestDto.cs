namespace Quizlo.API.Model.DTOs
{
    public class QuestionDTO
    {
        public int QuizID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public List <AnswerDTO> Answers { get; set; }
    }

    public class AnswerDTO
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.Model.Domain
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }

        public int QuestionID { get; set; }

        [MaxLength(100)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        [ForeignKey(nameof(QuestionID))]
        public Question Question { get; set; }
    }
}

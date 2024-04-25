using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public Question Question { get; set; }

    }
}

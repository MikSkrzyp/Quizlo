using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.Model.Domain
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int CreatorID { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey(nameof(CreatorID))]
        public User Creator { get; set; }

    }
}

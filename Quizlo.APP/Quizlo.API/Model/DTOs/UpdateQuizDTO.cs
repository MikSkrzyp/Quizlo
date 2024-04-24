using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.Model.DTOs
{
    public class UpdateQuizDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        /*[Required]
        public string CreatorID { get; set; }*/

        /*[Required]
        public DateTime DateCreated { get; set; }*/
    }
}

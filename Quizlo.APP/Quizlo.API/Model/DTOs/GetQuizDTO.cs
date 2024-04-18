using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Quizlo.API.Model.Domain;

namespace Quizlo.API.Model.DTOs
{
    public class GetQuizDTO
    {
        
        public int QuizID { get; set; }

    
        public string Title { get; set; }

        
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        
        public User Creator { get; set; }
    }
}

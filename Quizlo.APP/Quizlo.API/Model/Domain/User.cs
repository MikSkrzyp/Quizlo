using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Quizlo.API.Model.Domain
{
    public class User : IdentityUser
    {
        /*
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime DateRegistered { get; set; }*/
       public string FirstName { get; set; }
       public string LastName { get; set; }
    }
}

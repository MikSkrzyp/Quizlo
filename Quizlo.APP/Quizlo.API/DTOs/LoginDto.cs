using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.DTOs
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6,ErrorMessage ="Password should be between {2} and {1} characters")]
        public string Password { get; set; }

    }
}

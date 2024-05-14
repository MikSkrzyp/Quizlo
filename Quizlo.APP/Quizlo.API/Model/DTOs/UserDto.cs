using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.Model.DTOs;

public class UserDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}
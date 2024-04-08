using System.ComponentModel.DataAnnotations;

namespace Quizlo.API.DTOs;

public class UserDto
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
}
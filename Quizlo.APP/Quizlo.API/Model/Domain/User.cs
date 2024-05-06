using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Quizlo.API.Model.Domain
{
    public class User : IdentityUser
    {
      
        public string FirstName { get; set; }
       public string LastName { get; set; }
    }
}

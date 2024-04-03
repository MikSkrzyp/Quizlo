using Microsoft.EntityFrameworkCore;

namespace Quizlo.API.Data
{
    public class QuizloDbContext : DbContext
    {
        public QuizloDbContext(DbContextOptions<QuizloDbContext> options) : base(options)
        {
            
        }


    }
}

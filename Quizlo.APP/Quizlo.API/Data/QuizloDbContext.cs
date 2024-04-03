using Microsoft.EntityFrameworkCore;
using Quizlo.API.Model.Domain;

namespace Quizlo.API.Data
{
    public class QuizloDbContext : DbContext
    {
        public QuizloDbContext(DbContextOptions<QuizloDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        

    }
}

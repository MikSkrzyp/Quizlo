using Microsoft.EntityFrameworkCore;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;

namespace Quizlo.API.Repositories
{
    public class SQLQuizRepository : IQuizRepository
    {
        private readonly QuizloDbContext dbContext;

        public SQLQuizRepository(QuizloDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Quiz> CreateAsync(Quiz quiz)
        {
            await dbContext.Quizzes.AddAsync(quiz);
            await dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await dbContext.Quizzes.ToListAsync();
        }
    }
}

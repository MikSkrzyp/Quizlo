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

        public async Task<Quiz> DeleteAsync(int id)
        {
            var quiz = await dbContext.Quizzes.FirstOrDefaultAsync(x => x.QuizID == id);
            if (quiz == null)
            {
                return null;
            }
            dbContext.Quizzes.Remove(quiz);
            await dbContext.SaveChangesAsync();
            return quiz;
        }

        public async Task<List<Quiz>> GetAllAsync()
        {
            return await dbContext.Quizzes.Include("Creator").ToListAsync();
        }

        public async Task<Quiz> GetByIdAsync(int id)
        {
            return await dbContext.Quizzes.Include("Creator").FirstOrDefaultAsync(x=>x.QuizID==id);

        }

        public async Task<Quiz> UpadteAsync(int id, Quiz quiz)
        {
            var quiz_from_db = await dbContext.Quizzes.FirstOrDefaultAsync(x => x.QuizID == id);
            if (quiz_from_db == null)
            {
                return null;
            }
            quiz_from_db.Title = quiz.Title;
            quiz_from_db.Description = quiz.Description;
            //quiz_from_db.CreatorID = quiz.CreatorID;
            //quiz_from_db.DateCreated = quiz.DateCreated;

            await dbContext.SaveChangesAsync();
            return quiz_from_db;
        }
    }
}

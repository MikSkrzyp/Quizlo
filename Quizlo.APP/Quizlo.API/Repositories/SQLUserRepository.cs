using Microsoft.EntityFrameworkCore;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;

namespace Quizlo.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly QuizloDbContext dbContext;

        public SQLUserRepository(QuizloDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}

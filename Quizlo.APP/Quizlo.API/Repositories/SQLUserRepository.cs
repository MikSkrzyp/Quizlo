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

        public async Task<User> DeleteAsync(string id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null)
            {
                return null;
            }
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}

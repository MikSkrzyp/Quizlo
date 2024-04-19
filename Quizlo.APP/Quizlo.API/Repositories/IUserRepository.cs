using Quizlo.API.Model.Domain;

namespace Quizlo.API.Repositories
{
    public interface IUserRepository
    {

        Task<List<User>> GetAllAsync();

        Task<User> DeleteAsync(string id);

        Task<User> GetByIdAsync(string id);
    }
}

using Quizlo.API.Model.Domain;

namespace Quizlo.API.Repositories
{
    public interface IQuizRepository 
    {
        Task<Quiz> CreateAsync(Quiz quiz);
        Task<List<Quiz>> GetAllAsync();

        Task<Quiz> GetByIdAsync(int id);
        Task<Quiz> UpadteAsync(int id, Quiz quiz); 
        Task<Quiz> DeleteAsync(int id);

    }
}

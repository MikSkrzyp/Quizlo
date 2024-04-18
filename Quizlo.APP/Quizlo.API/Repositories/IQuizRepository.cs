using Quizlo.API.Model.Domain;

namespace Quizlo.API.Repositories
{
    public interface IQuizRepository 
    {
        Task<Quiz> CreateAsync(Quiz quiz);
        Task<List<Quiz>> GetAllAsync();
    }
}

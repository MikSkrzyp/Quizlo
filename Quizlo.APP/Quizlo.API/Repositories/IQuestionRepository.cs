using Quizlo.API.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizlo.API.Repositories
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task<IEnumerable<Question>> GetAllQuestionsAsync();
        Task<Question> GetQuestionByIdAsync(int questionId);

        Task<IEnumerable<Question>> GetAllQuestionsByQuizIdAsync(int quizId);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int questionId);
    }
}

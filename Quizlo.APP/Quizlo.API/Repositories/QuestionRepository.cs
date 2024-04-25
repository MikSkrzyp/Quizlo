using Microsoft.EntityFrameworkCore;
using Quizlo.API.Data;
using Quizlo.API.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quizlo.API.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizloDbContext _context;

        public QuestionRepository(QuizloDbContext context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Question>> GetAllQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.Questions.Include("Answers")
                .Where(q => q.QuizID == quizId)
                .ToListAsync();
        }
        public async Task UpdateQuestionAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            return await _context.Questions.FindAsync(questionId);
        }


    }
}

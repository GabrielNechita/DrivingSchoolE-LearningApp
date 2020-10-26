using DriversPlatform.DAL.Models;
using System.Collections.Generic;

namespace DriversPlatform.DAL.Repository
{
    public interface IQuestionRepository
    {
        void AddQuestion(Question newQuestion);
        void DeleteQuestion(int questionId);
        void UpdateQuestion(Question question);
        IList<Question> SearchQuestion(string searchText);
        List<Question> GetQuizByCategory(int categoryId);
        List<Question> GetQuizByDifficultyAndCategory(string difficulty, int categoryId);
    }
}
using DriversPlatform.DAL.Models;
using System.Collections;
using System.Collections.Generic;

namespace DriversPlatform.BLL.Services
{
    public interface IQuestionService
    {
        void AddQuestion(Question newQuestion);
        void DeleteQuestion(int questionId);
        void UpdateQuestion(Question question);
        IList<Question> SearchQuestion(string searchText);
    }
}
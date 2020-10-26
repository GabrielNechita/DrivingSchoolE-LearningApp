using DriversPlatform.DAL.Models;
using DriversPlatform.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriversPlatform.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void AddQuestion(Question newQuestion)
        {
            _questionRepository.AddQuestion(newQuestion);
        }

        public void DeleteQuestion(int questionId)
        {
            _questionRepository.DeleteQuestion(questionId);
        }

        public IList<Question> SearchQuestion(string searchText)
        {
            return _questionRepository.SearchQuestion(searchText);
        }

        public void UpdateQuestion(Question question)
        {
            _questionRepository.UpdateQuestion(question);
        }
    }
}

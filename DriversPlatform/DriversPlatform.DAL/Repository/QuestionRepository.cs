using DriversPlatform.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriversPlatform.DAL.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DatabaseContext _context;

        public QuestionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question newQuestion)
        {
            _context.Questions.Add(newQuestion);
            _context.SaveChanges();
        }

        public void DeleteQuestion(int questionId)
        {
            var questionFromDb = _context.Questions.FirstOrDefault(q => q.Id == questionId);
            _context.Questions.Remove(questionFromDb);
            _context.SaveChanges();
        }

        public List<Question> GetQuizByCategory(int categoryId)
        {
            return _context.Questions
                .Where(q => q.CategoryId == categoryId)
                .Include(q => q.Answers)
                .OrderBy(x => Guid.NewGuid())
                .Take(26)
                .ToList();
        }

        public List<Question> GetQuizByDifficultyAndCategory(string difficulty, int categoryId)
        {
            return _context.Questions
               .Where(q => q.CategoryId == categoryId && q.Difficulty == difficulty)
               .Include(q => q.Answers)
               .OrderBy(x => Guid.NewGuid())
               .Take(26)
               .ToList();
        }

        public IList<Question> SearchQuestion(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return _context.Questions.Include(q => q.Category).Include(q => q.Answers).ToList();
            }
            return _context.Questions.Include(q => q.Category).Include(q => q.Answers).Where(q => q.Value.Contains(searchText)).ToList();
        }

        public void UpdateQuestion(Question question)
        {
            var questionFromDb = _context.Questions
                .Include(q => q.Answers)
                .Include(q => q.Category)
                .FirstOrDefault(q => q.Id == question.Id);

            questionFromDb.Category = question.Category;
            questionFromDb.Difficulty = question.Difficulty;
            questionFromDb.Value = question.Value;
            for (int i = 0; i < questionFromDb.Answers.Count; i++)
            {
                questionFromDb.Answers[i].IsCorrect = question.Answers[i].IsCorrect;
                questionFromDb.Answers[i].Value = question.Answers[i].Value;
            }

            _context.SaveChanges(); 
        }
    }
}

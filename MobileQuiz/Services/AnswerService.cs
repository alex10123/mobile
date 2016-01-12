using System.Collections.Generic;
using System.Linq;

namespace MobileQuiz.Services
{
    public class AnswerService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public void AddAnswer(int questionId, string text, bool isRight)
        {
            _dbContext.AnswerSets.Add(new AnswerSet
            {
                QuestionId = questionId,
                Text = text,
                IsRight = isRight,
            });
            _dbContext.SaveChanges();
        }

        public void UpdateAnswer(int id, string title)
        {
            _dbContext.AnswerSets.First(x => x.Id == id).Text = title;
            _dbContext.SaveChanges();
        }

        public AnswerSet GetAnswerById(int id)
        {
            return _dbContext.AnswerSets.First(x => x.Id == id);
        }

        public List<AnswerSet> GetAllAnswers()
        {
            return _dbContext.AnswerSets.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileQuiz.Services
{
    public class UserAnswerService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public void AddUserAnswer(int answerId, int testId)
        {
            _dbContext.UserAnswerSets.Add(new UserAnswerSet
            {
                AnswerSet = _dbContext.AnswerSets.First(x => x.Id == answerId),
                TestSet = _dbContext.TestSets.First(x => x.Id == testId),
            });
            _dbContext.SaveChanges();
        }

        public UserAnswerSet GetTestById(int id)
        {
            return _dbContext.UserAnswerSets.First(x => x.Id == id);
        }

        public List<UserAnswerSet> GetAllTests()
        {
            return _dbContext.UserAnswerSets.ToList();
        }
    }
}
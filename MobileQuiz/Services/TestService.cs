using System.Collections.Generic;
using System.Linq;
using MobileQuiz.Models;

namespace MobileQuiz.Services
{
    public class TestService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public int  AddTest(int userId, int quizId)
        {
            var test = new TestSet
            {
                UserSet = _dbContext.UserSets.First(x => x.Id == userId),
                QuizSet = _dbContext.QuizSets.First(x => x.Id == quizId)
            };
            _dbContext.TestSets.Add(test);
            _dbContext.SaveChanges();
            return test.Id;
        }

        public TestSet GetTestById(int id)
        {
            return _dbContext.TestSets.First(x => x.Id == id);
        }

        public List<TestSet> GetAllTests()
        {
            return _dbContext.TestSets.ToList();
        }

        public List<Test> GetUserTests(int id) 
        {
            var tests = _dbContext.TestSets.Where(x => x.User_Id == id).ToList();
            var list = new List<Test>();
            foreach (var test in tests){
                list.Add(new Test{
                    Id = test.Id,
                    UserId = test.User_Id,
                    QuizId = test.Quiz_Id,
                    QuizTitle = test.QuizSet.Title,
                    RightAnswers = test.UserAnswerSets.Count(x => x.AnswerSet.IsRight),
                    TotalAnswers = test.QuizSet.QuestionSets.Count,
                });
            }
            return list;
        }

        public string GetTestResult(int id)
        {
            var test = _dbContext.TestSets.First(x=>x.Id == id);
            var rightAnswers = test.UserAnswerSets.Count(x => x.AnswerSet.IsRight);
            var totalAnswers = test.QuizSet.QuestionSets.Count;
            return rightAnswers + " из " + totalAnswers;

        }
    }
}
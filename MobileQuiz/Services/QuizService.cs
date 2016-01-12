using System.Collections.Generic;
using System.Linq;

namespace MobileQuiz.Services
{
    public class QuizService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public void AddQuiz(string title)
        {
            _dbContext.QuizSets.Add(new QuizSet {Title = title,});
            _dbContext.SaveChanges();
        }

        public void UpdateQuiz(int id, string title)
        {
            _dbContext.QuizSets.First(x => x.Id == id).Title = title;
            _dbContext.SaveChanges();
        }

        public Models.Quiz GetQuizById(int id)
        {
            var quiz = _dbContext.QuizSets.First(x => x.Id == id);
            var questions = new List<Models.Question>();
            foreach (var question in quiz.QuestionSets){
                questions.Add(new Models.Question{
                    Id = question.Id,
                    QuizId = question.QuizId,
                    Text = question.Text,
                });
            }
            return new Models.Quiz { 
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = questions,
            };
        }

        public List<Models.Quiz> GetAllQuizes()
        {
            var quizes = _dbContext.QuizSets.ToList();
            var list = new List<Models.Quiz>();
            foreach (var quiz in quizes) 
            {
                list.Add(new Models.Quiz
                {
                    Id = quiz.Id,
                    Title = quiz.Title,
                });
            }
            return list;
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MobileQuiz.Models;

namespace MobileQuiz.Services
{
    public class QuestionService
    {
        readonly MobileQuizEntities _dbContext = new MobileQuizEntities();

        public void AddQuestion(int quizId, string text)
        {
            _dbContext.QuestionSets.Add(new QuestionSet
                {
                    QuizId = quizId,
                    Text = text,
                    AnswerSets = new Collection<AnswerSet>(),
                });
            _dbContext.SaveChanges();
        }

        public void UpdateQuestion(int id, string title)
        {
            _dbContext.QuestionSets.First(x => x.Id == id).Text = title;
            _dbContext.SaveChanges();
        }

        public Question GetQuestionById(int id)
        {
            var question = _dbContext.QuestionSets.First(x => x.Id == id);
            return new Question
            {
                Id = question.Id,
                QuizId = question.QuizId,
                Text = question.Text,
            };
        }

        public List<QuestionSet> GetAllQuestions()
        {
            return _dbContext.QuestionSets.ToList();
        }

        public List<Question> GetQuizQuestions(int id) 
        {
            var questions = _dbContext.QuestionSets.Where(x=>x.QuizId == id).ToList();
            var list = new List<Question>();
            foreach (var question in questions) {
                list.Add(new Question { 
                    Id = question.Id,
                    Text = question.Text,
                    QuizId = question.QuizId,
                });
            }
            return list;
        }

        public void AddAnswer(int questionId, bool isRight, string text)
        {
            var answer = new AnswerSet
            {
                IsRight = isRight,
                QuestionId = questionId,
                Text = text,
            };
            _dbContext.AnswerSets.Add(answer);
            _dbContext.SaveChanges();
        }

        public List<Answer> GetQuestionAnswers(int questionId) 
        {
            var answers = _dbContext.AnswerSets.Where(x => x.QuestionId == questionId);
            var list = new List<Answer>();
            foreach (var answer in answers) 
            {
                list.Add(new Answer { 
                    Id = answer.Id,
                    IsRight = answer.IsRight,
                    QuestionId = answer.QuestionId,
                    Text = answer.Text,
                });
            }
            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileQuiz.Models;
using MobileQuiz.Services;

namespace MobileQuiz.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionService _questionService = new QuestionService();
        //
        // GET: /Question/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditQuestion(int id)
        {
            //var question = _questionService.GetQuestionById(id);
            var q = new Question
            {
                Id = 1,
                QuizId = 1,
                Text = " Вопрос 1",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = 1,
                        QuestionId = 1,
                        Text = "Ответ 1",
                        IsRight = true,
                    },
                    new Answer
                    {
                        Id = 2,
                        QuestionId = 1,
                        Text = "Ответ 2",
                        IsRight = false,
                    }
                }
            };
            return View("~/Views/Admin/Question/Index.cshtml", q);
        }

        public ActionResult GetQuestionAnswers(int id)
        {
            var answers = _questionService.GetQuestionAnswers(id);
            return Json(answers, JsonRequestBehavior.AllowGet);
        }

        public void AddAnswer(int questionId, bool isRight, string text)
        {
            _questionService.AddAnswer(questionId,isRight,text);
        }

        public void AddQuestion(int quizId, string text) {
            _questionService.AddQuestion(quizId, text);
        }
    }
}

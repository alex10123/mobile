using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileQuiz.Models;
using MobileQuiz.Services;

namespace MobileQuiz.Controllers
{
    public class QuizController : Controller
    {
        //
        // GET: /Quiz/

        QuizService quizService = new QuizService();
        QuestionService questionService = new QuestionService();
        TestService testService = new TestService();

        public ActionResult Index()
        {
            return View("~/Views/Admin/Test/Index.cshtml");
        }

        public ActionResult DisplayQuiz(int id) {
            var model = quizService.GetQuizById(id);
            var testId = testService.AddTest(int.Parse(Session["UserId"].ToString()),id);
            Session["TestId"] = testId;
            return View("~/Views/Quiz/Quiz.cshtml", model);
        }

        public ActionResult ListQuizes() 
        {
            return View("~/Views/Quiz/Index.cshtml");
        }

        public ActionResult EditQuiz(int id)
        {
            //var question = _questionService.GetQuestionById(id);
            var q = new Quiz
            {
                Id = 1,
                Title = "Quiz 1",
            };
            return View("~/Views/Admin/Quiz/Index.cshtml", q);
        }

        public ActionResult GetQuizQuestions(int id)
        {
            var questions = questionService.GetQuizQuestions(id);
            return Json(questions, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuizes()
        {
            var quizes = quizService.GetAllQuizes();            
            return Json(quizes, JsonRequestBehavior.AllowGet);
        }

        public void AddQuiz(string title) {
            quizService.AddQuiz(title);
        }
    }
}

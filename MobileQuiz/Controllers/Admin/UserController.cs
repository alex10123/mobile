using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileQuiz.Services;

namespace MobileQuiz.Controllers.Admin
{
    public class UserController : Controller
    {
        TestService testService = new TestService();
        UserService userService = new UserService();
        UserAnswerService userAnswerService = new UserAnswerService();
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View("~/Views/User/Login.cshtml");
        }
        
        [HttpGet]
        public ActionResult Register() 
        {
            return View("~/Views/User/Register.cshtml");
        }

        [HttpPost]
        public ActionResult Register(string email, string password, string name) 
        {
            var result = userService.AddUser(name, email, password);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserTests() 
        {
            var userId = int.Parse(Session["UserId"].ToString());
            var tests = testService.GetUserTests(userId);
            return Json(tests, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string email, string password) 
        {
            var userId = userService.Login(email, password);
            if (userId > 0){
                Session["UserId"] = userId;
            }
            return Json(userId, JsonRequestBehavior.AllowGet);
        }

        public void SaveAnswer(int answerId, int quizId) 
        {
            var testId = int.Parse(Session["TestId"].ToString());
            userAnswerService.AddUserAnswer(answerId, testId);
        }

        public ActionResult GetTestResult() 
        {
            var testId = int.Parse(Session["TestId"].ToString());
            var testResult = testService.GetTestResult(testId);
            return Json(testResult, JsonRequestBehavior.AllowGet);
        }

        public void Logout()
        {
            Session["UserId"] = null;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.UserAnswer;
using Online_Exam_System.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Online_Exam_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IExam ClsExams;
        private readonly IUserAnswer ClsUserAnswer;
        public HomeController(IExam exam,IUserAnswer userAnswer)
        {
            ClsExams = exam;
            ClsUserAnswer = userAnswer;
        }
        public async Task<IActionResult> Index()
        {
            var list= await ClsExams.GetAllAsync();
            return View(list);
        }
        public async Task<IActionResult> StartExam(int examId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (await ClsExams.HasUserCompletedExamAsync(userId, examId))
            {
                TempData["ErrorMessage"] = "Exam not found!";
                return RedirectToAction("Index", "Home");
            }

            var exam = await ClsExams.GetExamWithQuestionsAsync(examId);
            if (exam == null)
            {
                TempData["ErrorMessage"] = "Exam not found!";
                return RedirectToAction("Index", "Home");
            }

            return View(exam);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitExam([FromBody] UserExamAnswersDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid exam data.");

            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await ClsUserAnswer.SaveUserAnswersAsync(model);
            if (!result)
                return BadRequest("Failed to submit exam!");

            var examResult = await ClsUserAnswer.GetExamResultAsync(model);
            return Ok(examResult);
        }

    }
}

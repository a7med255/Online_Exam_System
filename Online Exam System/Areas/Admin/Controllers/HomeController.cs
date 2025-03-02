using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.Exam;
using Online_Exam_System.Models;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly IExam ClsExams;
        private readonly IQuestion ClsQuestions;
        public HomeController(IExam exam,IQuestion question)
        {
            ClsExams = exam;
            ClsQuestions = question;
        }
        public async Task<IActionResult> Index()//GetAllExams
        {
            try
            {
                var list = await ClsExams.GetAllAsync();
                return View(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllExamsAsync: {ex.Message}");

                TempData["ErrorMessage"] = "Error";
                return RedirectToAction("Index", "Home"); 
            }
        }

        public IActionResult Add()//addExams
        {
            return View(new ExamDto());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamDto exam)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(exam);
                }

                var newExam = new Exam
                {
                    Title = exam.Title,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "Admin",
                    CurrentState = true
                };

                var issave= await ClsExams.AddAsync(newExam);
                if (issave) {
                return Redirect("~/Admin/Home/Index");
                }
            }
            catch (Exception ex)
            {
                return View(exam);
            }
            return View(exam);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var exam = await ClsExams.GetByIdAsync(id);

            if (exam == null)
            {
                TempData["ErrorMessage"] = "NotFound";
            }

            var examDto = new ExamEditDto
            {
                Id = id,
                Title = exam.Title
            };

            return View(examDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ExamDto exam)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(exam);
                }
                var existingExam = await ClsExams.GetByIdAsync(id);

                if (existingExam == null)
                {
                    TempData["ErrorMessage"] = "NotFound";
                }

                existingExam.Title = exam.Title;
                existingExam.UpdatedAt = DateTime.Now;
                existingExam.UpdatedBy = "Admin";

                await ClsExams.UpdateAsync(id,existingExam);

                return Redirect("~/Admin/Home/Index");
            }
            catch (Exception ex)
            {
                return View(exam);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var exam = await ClsExams.GetByIdAsync(id);
                if (exam == null)
                {
                    TempData["ErrorMessage"] = "NotFound";
                }

                await ClsExams.DeleteAsync(id);

                return RedirectToAction("Index"); 
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { errorMessage = "Failed to delete exam" });
            }
        }


    }
}

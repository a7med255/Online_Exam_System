using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Bl.Repositories;
using Online_Exam_System.Dtos.Exam;
using Online_Exam_System.Dtos.Question;
using Online_Exam_System.Models;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    [Area("admin")]
    public class QuestionController : Controller
    {
        private readonly IQuestion ClsQuestions;
        public QuestionController(IQuestion question)
        {
            ClsQuestions = question;
        }
        public async Task<IActionResult> List(int examid)
        {
            try
            {
                ViewBag.ExamId = examid;
                var list = await  ClsQuestions.GetAllWithExamAsync(examid);
                return View(list);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error";
                return RedirectToAction("Index", "Home");
            }
        }
        
        public IActionResult Add(int examid)//addQuestions
        {
            var question = new QuestionDto { ExamId = examid };
            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> Add(QuestionDto question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }
            try
            {
                var newquestion = new Question
                {
                    ExamId = question.ExamId,
                    QuestionText =question.QuestionText,
                    Option1 = question.Option1,
                    Option2 = question.Option2,
                    Option3 = question.Option3,
                    Option4 = question.Option4,
                    CorrectAnswer = question.CorrectAnswer,
                };

                var issave = await ClsQuestions.AddAsync(newquestion);
                if (issave)
                {
                    return RedirectToAction("List", new { examid = question.ExamId });
                }
            }
            catch (Exception ex)
            {
                return View(question);
            }
            return View(question);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var question = await ClsQuestions.GetByIdAsync(id);

            if (question == null)
            {
                TempData["ErrorMessage"] = "NotFound";
            }

            var questionEditDto = new QuestionEditDto
            {
                Id = id,
                ExamId=question.ExamId,
                QuestionText= question.QuestionText,
                Option1 = question.Option1,
                Option2 = question.Option2,
                Option3 = question.Option3,
                Option4 = question.Option4,
                CorrectAnswer= question.CorrectAnswer,
            };

            return View(questionEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, QuestionEditDto questionEdit)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(questionEdit);
                }
                var existingquestion = await ClsQuestions.GetByIdAsync(id);

                if (existingquestion == null)
                {
                    TempData["ErrorMessage"] = "NotFound";
                }
                existingquestion.QuestionText= questionEdit.QuestionText;
                existingquestion.Option1 = questionEdit.Option1;
                existingquestion.Option2 = questionEdit.Option2;
                existingquestion.Option3 = questionEdit.Option3;
                existingquestion.Option4 = questionEdit.Option4;
                existingquestion.CorrectAnswer = questionEdit.CorrectAnswer;


                var update= await ClsQuestions.UpdateAsync(id, existingquestion);
                if(update)
                {
                    return RedirectToAction("List", new { examid = existingquestion.ExamId });
                }

            }
            catch (Exception ex)
            {
                return View(questionEdit);
            }
            return View(questionEdit);
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var question = await ClsQuestions.GetByIdAsync(id);
                if (question == null)
                {
                    TempData["ErrorMessage"] = "NotFound";
                }

               var remove= await ClsQuestions.DeleteAsync(id);
                if(remove)
                {
                    return RedirectToAction("List", new { examid = question.ExamId });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("List", new { errorMessage = "Failed to delete exam" });
            }
            return View("List");
        }
    }
}

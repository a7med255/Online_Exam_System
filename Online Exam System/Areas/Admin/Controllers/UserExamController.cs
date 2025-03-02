using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class UserExamController : Controller
    {
        private readonly IUserExam ClsUserExams;
        public UserExamController(IUserExam userExam)
        {
            ClsUserExams = userExam;
        }
        public async Task<IActionResult> GetAll(string userId)
        {
            var list = await ClsUserExams.GetUserExamWithUserAsync(userId);
            return View(list);
        }
    }
}

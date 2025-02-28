using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

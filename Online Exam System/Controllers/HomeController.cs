using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Models;
using System.Diagnostics;

namespace Online_Exam_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}

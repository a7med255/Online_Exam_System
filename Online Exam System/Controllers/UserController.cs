using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.Auth;
using Online_Exam_System.Models;

namespace Online_Exam_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }
        public IActionResult Login()
        {
            return View(new Login());
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            ApplicationUser users = new ApplicationUser()
            {
                Email = login.Email,
                UserName = login.Email
            };
            try
            {
                var loginResult = await _userService.LoginAsync(login);
                if (!loginResult.result)
                {
                    TempData["ErrorMessage"] = loginResult.Message;
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View(new Login());
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Login", "User");
        }

    }
}

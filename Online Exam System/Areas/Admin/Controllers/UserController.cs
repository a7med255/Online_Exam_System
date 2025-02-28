using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.Auth;
using Online_Exam_System.Models;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult AddUser()
        {
            return View(new User());
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)    
                return View("AddUser", user);

            ApplicationUser users = new ApplicationUser()
            {
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.Email,
            };
            try
            {
                var result = await _userService.CreateUserAsync(user);
                if (result.result)  
                {
                    TempData["SuccessMessage"] = result.Message;
                    return Redirect("~/Admin/User/AddUser");
                }
                else
                {
                    TempData["ErrorMessage"] = result.Message;
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] =  ex.Message;
            }

            return View(user);
        }
    }
}

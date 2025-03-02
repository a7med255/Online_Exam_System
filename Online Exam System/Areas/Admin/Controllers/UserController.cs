using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.Auth;
using Online_Exam_System.Models;

namespace Online_Exam_System.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                if (users == null || !users.Any())
                {
                    return View(new List<ApplicationUser>()); 
                }

                return View(users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
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
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Login", "User");
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUserAsync(id);

                if (isDeleted)
                {
                    TempData["SuccessMessage"] = "User deleted successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "User not found or couldn't be deleted.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the user.";
            }

            return RedirectToAction("GetAllUser");
        }

    }
}

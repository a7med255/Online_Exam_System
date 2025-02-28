using Microsoft.AspNetCore.Identity;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Models;
using Online_Exam_System.Bl;
using Online_Exam_System.Dtos.Auth;

namespace Online_Exam_System.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ExamContext context;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
             ExamContext context, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            _roleManager = roleManager;
            this.context = context;
            _signInManager = signInManager;
        }
        public async Task<AuthModel> CreateUserAsync(User model)
        {
            if (await userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel
                {
                    Message = "Email is already registerd!"
                };
            }


            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel { Message = errors };

            }

            await userManager.AddToRoleAsync(user, "User");


            return new AuthModel
            {
                Message ="Added User",
                result = true
            };
        }

        public async Task<AuthModel> LoginAsync(Login login)
        {
            var authModel = new AuthModel();

            var user = await userManager.FindByEmailAsync(login.Email);

            if (user is null || !await userManager.CheckPasswordAsync(user, login.Password) )
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, isPersistent: false, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                authModel.Message = "Email or Password is incorrect!";
                return authModel;
            }

            authModel.Message = "Login Sucssefully";
            authModel.result= true;
            return authModel;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}

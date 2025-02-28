using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Exam_System.Dtos.Auth;
using Online_Exam_System.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IUserService
    {
        Task<AuthModel> CreateUserAsync(User register);
        Task<AuthModel> LoginAsync(Login login);
        Task LogoutAsync();
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<bool> DeleteUserAsync(string userId);
    }
}

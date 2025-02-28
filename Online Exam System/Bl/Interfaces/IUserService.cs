using Microsoft.AspNetCore.Identity;
using Online_Exam_System.Dtos.Auth;
using System.IdentityModel.Tokens.Jwt;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IUserService
    {
        Task<AuthModel> CreateUserAsync(User register);
        Task<AuthModel> LoginAsync(Login login);
        Task LogoutAsync();
    }
}

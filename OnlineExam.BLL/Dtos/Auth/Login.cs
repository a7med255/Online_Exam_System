using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Dtos.Auth
{
    public class Login
    {
        [Required(ErrorMessage = "Enter You Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter You Password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).+$", ErrorMessage = "Password must contain at least one uppercase letter and one non-alphanumeric character.")]
        public string Password { get; set; }
    }
}

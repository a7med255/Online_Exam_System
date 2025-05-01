using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; } = new List<UserExam>();
        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}

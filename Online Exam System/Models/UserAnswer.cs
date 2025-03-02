using Online_Exam_System.Dtos.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int UserExamId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [StringLength(255)]
        public string UserAnswerChoise { get; set; } 

        public bool IsCorrect { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("UserExamId")]
        public virtual UserExam UserExam { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}

using Online_Exam_System.Dtos.Auth;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class UserExam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ExamId { get; set; }

        public int? Score { get; set; }

        public bool Passed { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(255)]
        public string? UpdatedBy { get; set; }

        public bool IsCompleted { get; set; } = false;

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}

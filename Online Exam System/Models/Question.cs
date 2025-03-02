using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Exam")]
        [Required]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }

        [Required]
        [StringLength(255)]
        public string Option1 { get; set; }

        [Required]
        [StringLength(255)]
        public string Option2 { get; set; }

        [StringLength(255)]
        public string? Option3 { get; set; }

        [StringLength(255)]
        public string? Option4 { get; set; }

        [Required]
        [StringLength(255)]
        public string CorrectAnswer { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}

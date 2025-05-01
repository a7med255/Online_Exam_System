using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Dtos.Question
{
    public class QuestionDto
    {

        public int ExamId { get; set; }
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
    }
}

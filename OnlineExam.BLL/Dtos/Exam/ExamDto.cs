using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Dtos.Exam
{
    public class ExamDto
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
    }
}

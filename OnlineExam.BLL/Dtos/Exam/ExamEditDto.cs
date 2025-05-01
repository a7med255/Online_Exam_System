using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Dtos.Exam
{
    public class ExamEditDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
    }
}

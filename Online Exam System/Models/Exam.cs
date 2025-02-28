using System.ComponentModel.DataAnnotations;

namespace Online_Exam_System.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        [StringLength(255)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [StringLength(255)]
        public string? UpdatedBy { get; set; }

        public bool CurrentState { get; set; }
        public ICollection<Question> TbQuestions { get; set; }
    }
}

using Online_Exam_System.Dtos.Question;

namespace Online_Exam_System.Dtos.Exam
{
    public class ExamWithQuestionsDto
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public List<ShowQuestionDto> Questions { get; set; }
    }
}

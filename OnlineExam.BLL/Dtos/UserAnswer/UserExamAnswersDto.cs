namespace Online_Exam_System.Dtos.UserAnswer
{
    public class UserExamAnswersDto
    {
        public string? UserId { get; set; }
        public int ExamId { get; set; }
        public List<UserAnswerDto> Answers { get; set; }
    }
}

namespace Online_Exam_System.Dtos.UserAnswer
{
    public class ExamResultDetailDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}

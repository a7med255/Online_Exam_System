namespace Online_Exam_System.Dtos.UserAnswer
{
    public class ExamResultDto
    {
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public double Score { get; set; }
        public List<ExamResultDetailDto> ExamResults { get; set; }
    }
}

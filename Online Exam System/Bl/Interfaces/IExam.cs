using Online_Exam_System.Dtos.Exam;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IExam : IRepository<Exam>
    {
        Task<ExamWithQuestionsDto> GetExamWithQuestionsAsync(int examId);
        Task<bool> HasUserCompletedExamAsync(string userId, int examId);
    }
}

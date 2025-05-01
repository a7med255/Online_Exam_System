using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IQuestion : IRepository<Question>
    {
        Task<IEnumerable<Question>> GetAllWithExamAsync(int ExamId);
    }
}

using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IUserExam : IRepository<UserExam>
    {
        Task<IEnumerable<UserExam>> GetUserExamWithUserAsync(string userid);
    }
}

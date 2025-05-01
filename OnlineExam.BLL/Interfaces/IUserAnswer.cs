using Online_Exam_System.Dtos.UserAnswer;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IUserAnswer: IRepository<UserAnswer>
    {
        Task<bool> SaveUserAnswersAsync(UserExamAnswersDto userAnswers);
        Task<ExamResultDto> GetExamResultAsync(UserExamAnswersDto model);
    }
}

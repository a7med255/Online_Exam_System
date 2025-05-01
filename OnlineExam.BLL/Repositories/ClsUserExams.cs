using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Repositories
{
    public class ClsUserExams : Repositories<UserExam>, IUserExam
    {
        private readonly ExamContext context;
        public ClsUserExams(ExamContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserExam>> GetUserExamWithUserAsync(string userId)
        {
            try
            {
                return await context.TbUserExams
                        .Include(ue => ue.User) 
                        .Include(ue => ue.Exam)
                        .Where(ue => ue.UserId == userId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<UserExam>();
            }
        }
    }
}

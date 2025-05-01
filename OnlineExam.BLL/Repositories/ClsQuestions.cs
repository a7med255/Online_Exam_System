using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Repositories
{
    public class ClsQuestions:Repositories<Question>,IQuestion
    {
        private readonly ExamContext context;
        public ClsQuestions( ExamContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Question>> GetAllWithExamAsync(int ExamId)
        {
            try
            {
                var questions = await context.TbQuestions.Where(a => a.ExamId == ExamId).Include(a=>a.Exam).ToListAsync();
                return questions;
            }
            catch
            {
                return new List<Question>();
            }
        }
    }
}

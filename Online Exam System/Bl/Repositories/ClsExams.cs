using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.Exam;
using Online_Exam_System.Dtos.Question;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Repositories
{
    public class ClsExams: Repositories<Exam>,IExam
    {
        private readonly ExamContext context;

        public ClsExams(ExamContext _context) : base(_context)
        {
            context = _context;
        }
        public async Task<ExamWithQuestionsDto> GetExamWithQuestionsAsync(int examId)
        {
            var exam = await context.TbExams
                .Include(e => e.TbQuestions)
                .FirstOrDefaultAsync(e => e.Id == examId);

            if (exam == null) 
                return null;

            return new ExamWithQuestionsDto
            {
                ExamId = exam.Id,
                ExamTitle = exam.Title,
                Questions = exam.TbQuestions.Select(q => new ShowQuestionDto
                {
                    Id = q.Id,
                    QuestionText = q.QuestionText,
                    Option1 = q.Option1,
                    Option2 = q.Option2,
                    Option3 = q.Option3,
                    Option4 = q.Option4
                }).ToList()
            };
        }
        public async Task<bool> HasUserCompletedExamAsync(string userId, int examId)
        {
            return await context.TbUserExams
                .AnyAsync(ue => ue.UserId == userId && ue.ExamId == examId && ue.IsCompleted);
        }
    }
}

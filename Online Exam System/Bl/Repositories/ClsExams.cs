using Online_Exam_System.Bl.Interfaces;
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
    }
}

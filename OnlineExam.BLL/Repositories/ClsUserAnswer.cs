    using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Bl.Interfaces;
using Online_Exam_System.Dtos.UserAnswer;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl.Repositories
{
    public class ClsUserAnswer: Repositories<UserAnswer>, IUserAnswer
    {
        private readonly ExamContext context;

        public ClsUserAnswer(ExamContext context):base(context)
        {
            this.context = context;
        }

        public async Task<bool> SaveUserAnswersAsync(UserExamAnswersDto userAnswers)
        {
            if (userAnswers == null || !userAnswers.Answers.Any())
                return false;

            var userExam = await context.TbUserExams
                .FirstOrDefaultAsync(ue => ue.UserId == userAnswers.UserId && ue.ExamId == userAnswers.ExamId);

            if (userExam == null)
            {
                userExam = new UserExam
                {
                    UserId = userAnswers.UserId,
                    ExamId = userAnswers.ExamId,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userAnswers.UserId,
                    IsCompleted = false
                };

                await context.TbUserExams.AddAsync(userExam);
                await context.SaveChangesAsync();
            }

            var questionIds = userAnswers.Answers.Select(a => a.QuestionId).ToList();
            var existingQuestions = await context.TbQuestions
                .Where(q => questionIds.Contains(q.Id))
                .ToDictionaryAsync(q => q.Id, q => q.CorrectAnswer);

            var userExamAnswers = userAnswers.Answers.Select(a => new UserAnswer
            {
                UserId = userAnswers.UserId,
                UserExamId = userExam.Id,
                QuestionId = a.QuestionId,
                UserAnswerChoise = a.UserAnswerChoise,
                IsCorrect = existingQuestions[a.QuestionId] == a.UserAnswerChoise
            }).ToList();

            await context.TbUserAnswers.AddRangeAsync(userExamAnswers);
            await context.SaveChangesAsync();

            int correctAnswers = userExamAnswers.Count(a => a.IsCorrect);
            double score = (correctAnswers / (double)userAnswers.Answers.Count) * 100;
            bool passed = score >= 60;

            userExam.Score = (int)score;
            userExam.Passed = passed;
            userExam.IsCompleted = true;
            userExam.UpdatedAt = DateTime.Now;
            userExam.UpdatedBy = userAnswers.UserId;

            context.TbUserExams.Update(userExam);
            await context.SaveChangesAsync();

            return true;
        }
        public async Task<ExamResultDto> GetExamResultAsync(UserExamAnswersDto model)
        {
            var correctAnswers = await context.TbQuestions
                .Where(q => model.Answers.Select(a => a.QuestionId).Contains(q.Id))
                .ToDictionaryAsync(q => q.Id, q => new
                {
                    q.QuestionText,
                    q.CorrectAnswer
                });

            int correctCount = 0, wrongCount = 0;
            var examResults = new List<ExamResultDetailDto>();

            foreach (var answer in model.Answers)
            {
                bool isCorrect = correctAnswers[answer.QuestionId].CorrectAnswer == answer.UserAnswerChoise;

                if (isCorrect) correctCount++;
                else wrongCount++;

                examResults.Add(new ExamResultDetailDto
                {
                    QuestionId = answer.QuestionId,
                    QuestionText = correctAnswers[answer.QuestionId].QuestionText,
                    UserAnswer = answer.UserAnswerChoise,
                    CorrectAnswer = correctAnswers[answer.QuestionId].CorrectAnswer,
                    IsCorrect = isCorrect
                });
            }

            double score = (correctCount / (double)model.Answers.Count) * 100;

            return new ExamResultDto
            {
                CorrectCount = correctCount,
                WrongCount = wrongCount,
                Score = score,
                ExamResults = examResults
            };
        }
    }
}

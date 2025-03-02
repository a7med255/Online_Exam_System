using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Exam_System.Models;

namespace Online_Exam_System.Bl
{
    public class ExamContext : IdentityDbContext<ApplicationUser>
    {
        public ExamContext()
        {
            
        }
        public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>() // Exam 1 -> m Questions
                .HasOne(q => q.Exam)
                .WithMany(e => e.TbQuestions)
                .HasForeignKey(q => q.ExamId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<UserExam>() // Exam 1 -> m UserExams
                .HasOne(ue => ue.Exam)
                .WithMany(e => e.UserExams)
                .HasForeignKey(ue => ue.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserExam>() // User 1 -> m UserExams
                .HasOne(ue => ue.User)
                .WithMany(u => u.UserExams)
                .HasForeignKey(ue => ue.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAnswer>() // User 1 -> m UserAnswers
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnswers)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserAnswer>() // UserExam 1 -> m UserAnswers
                .HasOne(ua => ua.UserExam)
                .WithMany(ue => ue.UserAnswers)
                .HasForeignKey(ua => ua.UserExamId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAnswer>() // Question 1 -> m UserAnswers
                .HasOne(ua => ua.Question)
                .WithMany(q => q.UserAnswers)
                .HasForeignKey(ua => ua.QuestionId)
                 .OnDelete(DeleteBehavior.Cascade);
        }


        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Exam> TbExams { get; set; }
        public DbSet<Question> TbQuestions { get; set; }
        public DbSet<UserExam> TbUserExams { get; set; }
        public DbSet<UserAnswer> TbUserAnswers { get; set; }
    }
}

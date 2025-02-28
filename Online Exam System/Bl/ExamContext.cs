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
        }


        public DbSet<ApplicationUser> Users { get; set; }

    }
}

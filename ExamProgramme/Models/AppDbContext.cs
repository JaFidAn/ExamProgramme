using Microsoft.EntityFrameworkCore;

namespace ExamProgramme.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Exam> Exams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

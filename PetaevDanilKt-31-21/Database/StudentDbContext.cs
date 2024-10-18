using Microsoft.EntityFrameworkCore;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Database.Configurations;

namespace PetaevDanilKt_31_21.Database
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
    }
}

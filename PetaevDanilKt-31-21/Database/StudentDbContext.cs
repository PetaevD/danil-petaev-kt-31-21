using Microsoft.EntityFrameworkCore;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Database.Configurations;

namespace PetaevDanilKt_31_21.Database
{
    public class StudentDbContext : DbContext
    {
        // Добавляем таблицы
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавляем конфигурации к таблицам
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

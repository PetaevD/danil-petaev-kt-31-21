using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "Grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_grade_id");

            // Автогенерация для первичного ключа
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Свойства таблицы
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор оценки");

            builder
                .Property(p => p.Score)
                .IsRequired()
                .HasColumnName("score")
                .HasColumnType(ColumnType.Int)
                .HasComment("Оценка");

            builder
                 .Property(p => p.StudentId)
                 .IsRequired()
                 .HasColumnName("studentId")
                 .HasColumnType(ColumnType.Int)
                 .HasComment("Идентификатор студента");

            builder
                 .Property(p => p.DisciplineId)
                 .IsRequired()
                 .HasColumnName("disciplineId")
                 .HasColumnType(ColumnType.Int)
                 .HasComment("Идентификатор предмета");

            builder
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.StudentId, $"ind_{TableName}_fk_student_id");

            builder
                 .Navigation(p => p.Student)
                 .AutoInclude();

            builder
                .HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.DisciplineId, $"ind_{TableName}_fk_discipline_id");

            builder
                 .Navigation(p => p.Discipline)
                 .AutoInclude();

            builder
                 .ToTable(TableName);
        }
    }
}

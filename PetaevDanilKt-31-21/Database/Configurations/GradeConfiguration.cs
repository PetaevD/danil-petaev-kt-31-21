using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_grade_id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Id)
                .HasColumnName("grade_id")
                .HasComment("Идентификатор оценки");

            builder
                .Property(p => p.Score)
                .IsRequired()
                .HasColumnName("c_grade_score")
                .HasColumnType(ColumnType.Int)
                .HasComment("Оценка");

            builder
                 .Property(p => p.StudentId)
                 .IsRequired()
                 .HasColumnName("c_grade_student_id")
                 .HasColumnType(ColumnType.Int)
                 .HasComment("Идентификатор студента");

            builder
                 .Property(p => p.DisciplineId)
                 .IsRequired()
                 .HasColumnName("c_grade_discipline_id")
                 .HasColumnType(ColumnType.Int)
                 .HasComment("Идентификатор предмета");

            builder
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .HasConstraintName("fk_f_student_id")
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
                .HasConstraintName("fk_f_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(p => p.DisciplineId, $"ind_{TableName}_fk_f_discipline_id");

            builder
                 .Navigation(p => p.Discipline)
                 .AutoInclude();

            builder
                 .ToTable(TableName);
        }
    }
}

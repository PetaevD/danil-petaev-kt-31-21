using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "cd_test";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_test_id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Id)
                .HasColumnName("test_id")
                .HasComment("Идентификатор зачета");

            builder
                .Property(p => p.IsPassed)
                .IsRequired()
                .HasColumnName("c_test_is_passed")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Зачет сдан/не сдан");

            builder
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_f_student_id");

            builder
                .HasIndex(p => p.StudentId)
                .HasDatabaseName($"ind_{TableName}_fk_f_student_id");

            // Связь с таблицей Discipline
            builder
                .HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_f_discipline_id");

            builder
                .HasIndex(p => p.DisciplineId)
                .HasDatabaseName($"ind_{TableName}_fk_f_discipline_id");

            // Указываем имя таблицы
            builder
                .ToTable(TableName);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        private const string TableName = "Test";

        public void Configure(EntityTypeBuilder<Test> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_test_id");

            // Автогенерация для первичного ключа
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Свойства таблицы
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор зачета");

            builder
                .Property(p => p.IsPassed)
                .IsRequired()
                .HasColumnName("isPassed")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Зачет сдан/не сдан");

            // Связь с таблицей Student
            builder
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_{TableName}_student");

            builder
                .HasIndex(p => p.StudentId)
                .HasDatabaseName($"ind_{TableName}_fk_student_id");

            // Связь с таблицей Discipline
            builder
                .HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_{TableName}_discipline");

            builder
                .HasIndex(p => p.DisciplineId)
                .HasDatabaseName($"ind_{TableName}_fk_discipline_id");

            // Указываем имя таблицы
            builder
                .ToTable(TableName);
        }
    }
}

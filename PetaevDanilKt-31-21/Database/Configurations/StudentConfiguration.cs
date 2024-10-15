using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "Student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_student_id");

            // Для int первичного ключа делаем автогенерацию
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Свойства таблицы
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор записи студента");

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("firstName")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Имя студента");

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Фамилия студента");

            builder
                .Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("middleName")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Отчество студента");

            builder
                .Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("groupId")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("isDeleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удален ли пользователь");

            // Связь с таблицей Group
            builder
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_{TableName}_group");

            builder
                .HasIndex(p => p.GroupId)
                .HasDatabaseName($"ind_{TableName}_fk_group_id");

            builder
                .ToTable(TableName);
        }
    }
}

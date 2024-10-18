using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_student_id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Id)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Имя студента");

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Фамилия студента");

            builder
                .Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Отчество студента");

            builder
                .Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("c_student_group_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор группы");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удален ли пользователь");

            builder
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName($"fk_f_group_id");

            builder
                .HasIndex(p => p.GroupId)
                .HasDatabaseName($"ind_{TableName}_fk_f_group_id");

            builder
                .ToTable(TableName);
        }
    }
}

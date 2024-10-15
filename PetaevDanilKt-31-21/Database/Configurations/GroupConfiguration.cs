using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "Group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_group_id");

            // Автогенерация для первичного ключа
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Свойства таблицы
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор группы");

            builder
                .Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Название группы");

            builder
                .Property(p => p.Speciality)
                .IsRequired()
                .HasColumnName("speciality")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Специальность группы");

            builder
                .Property(p => p.StartYear)
                .IsRequired()
                .HasColumnName("startYear")
                .HasColumnType(ColumnType.Int)
                .HasComment("Год начала обучения");

            builder
                .Property(p => p.YearGraduation)
                .IsRequired()
                .HasColumnName("yearGraduation")
                .HasColumnType(ColumnType.Int)
                .HasComment("Год выпуска");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("isDeleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удалена ли группа");
        }
    }
}

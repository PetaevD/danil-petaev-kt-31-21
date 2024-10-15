using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            // Задаем первичный ключ
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_discipline_id");

            // Автогенерация для первичного ключа
            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Свойства таблицы
            builder
                .Property(p => p.Id)
                .HasColumnName("id")
                .HasComment("Идентификатор предмета");

            builder
                .Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("disciplineName")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .HasComment("Название предмета");

            builder
                .Property(p => p.IsHumanities)
                .IsRequired()
                .HasColumnName("isHumanities")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Гуманитарное направление");

            builder
                .Property(p => p.IsTechnical)
                .IsRequired()
                .HasColumnName("isTechnical")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Техническое направление");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("isDeleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удален ли предмет");
        }
    }
}

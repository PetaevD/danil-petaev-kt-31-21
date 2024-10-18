using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_discipline_id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Id)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор предмета");

            builder
                .Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(50)
                .HasComment("Название предмета");

            builder
                .Property(p => p.IsHumanities)
                .IsRequired()
                .HasColumnName("c_discipline_is_humanities")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Гуманитарное направление");

            builder
                .Property(p => p.IsTechnical)
                .IsRequired()
                .HasColumnName("c_discipline_is_technical")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Техническое направление");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удален ли предмет");

            builder
                 .ToTable(TableName);
        }
    }
}

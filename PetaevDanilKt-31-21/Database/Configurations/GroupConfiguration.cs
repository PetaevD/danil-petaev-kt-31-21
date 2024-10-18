using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Helpers;

namespace PetaevDanilKt_31_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(p => p.Id)
                .HasName($"pk_{TableName}_group_id");

            builder
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Id)
                .HasColumnName("group_id")
                .HasComment("Идентификатор группы");

            builder
                .Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Название группы");

            builder
                .Property(p => p.Speciality)
                .IsRequired()
                .HasColumnName("c_group_speciality")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(25)
                .HasComment("Специальность группы");

            builder
                .Property(p => p.StartYear)
                .IsRequired()
                .HasColumnName("c_group_start_year")
                .HasColumnType(ColumnType.Int)
                .HasComment("Год начала обучения");

            builder
                .Property(p => p.YearGraduation)
                .IsRequired()
                .HasColumnName("c_group_year_graduation")
                .HasColumnType(ColumnType.Int)
                .HasComment("Год выпуска");

            builder
                .Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("c_is_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Удалена ли группа");
        }
    }
}

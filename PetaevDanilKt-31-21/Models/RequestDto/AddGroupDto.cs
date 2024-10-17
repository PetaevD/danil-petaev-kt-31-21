namespace PetaevDanilKt_31_21.Models.RequestDto
{
    public class AddGroupDto
    {
        public string? Name { get; set; }

        public string? Speciality { get; set; }

        public int? StartYear { get; set; }

        public int YearGraduation { get; set; }

        public bool IsDeleted { get; set; }
    }
}

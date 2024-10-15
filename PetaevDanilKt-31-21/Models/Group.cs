namespace PetaevDanilKt_31_21.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string? GroupName { get; set; }

        public string? Speciality { get; set; }

        public int? StartYear { get; set; }

        public int YearGraduation { get; set; }

        public bool IsDeleted { get; set; }
    }
}

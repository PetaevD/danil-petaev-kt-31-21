namespace PetaevDanilKt_31_21.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? MiddleName { get; set; }

        public int GroupId { get; set; }

        public Group? Group { get; set; }

        public bool IsDeleted { get; set; }
    }
}


namespace PetaevDanilKt_31_21.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        public string? DisciplineName { get; set; }

        public bool IsHumanities { get; set; }

        public bool IsTechnical { get; set; }

        public bool IsDeleted { get; set; }
    }
}

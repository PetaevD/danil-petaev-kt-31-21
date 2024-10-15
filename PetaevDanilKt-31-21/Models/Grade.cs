namespace PetaevDanilKt_31_21.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }

        public int DisciplineId { get; set; }

        public Discipline? Discipline { get; set; }
    }
}

using PetaevDanilKt_31_21.Database;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Models.RequestDto;
using Microsoft.EntityFrameworkCore;

namespace PetaevDanilKt_31_21.Interfaces.StudentInterfaces
{
    public interface IGradeService
    {
        public Task<Grade> AddGradeByStudent(int studentId, AddGradeDto newGrade, CancellationToken cancellationToken);
        public Task<Grade> ChangeGradeByStudent(int studentId, int gradeId, ChangeGradeDto newGrade, CancellationToken cancellationToken);
    }

    public class GradeService : IGradeService
    {
        private readonly StudentDbContext _dbContext;

        public GradeService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Grade> AddGradeByStudent(int studentId, AddGradeDto newGrade, CancellationToken cancellationToken = default)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId, cancellationToken);
            if (student == null)
            {
                throw new Exception("Студент не найден.");
            }

            var grade = new Grade
            {
                Score = newGrade.Score,
                StudentId = studentId,
                DisciplineId = newGrade.DisciplineId
            };

            _dbContext.Grades.Add(grade);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return grade;
        }

        public async Task<Grade> ChangeGradeByStudent(int studentId, int gradeId, ChangeGradeDto updatedGrade, CancellationToken cancellationToken = default)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == studentId, cancellationToken);
            if (student == null)
            {
                throw new Exception("Студент не найден.");
            }

            var existingGrade = await _dbContext.Grades.FirstOrDefaultAsync(g => g.Id == gradeId && g.StudentId == studentId, cancellationToken);
            if (existingGrade == null)
            {
                throw new Exception("Оценка не найдена.");
            }

            existingGrade.Score = updatedGrade.Score;
            existingGrade.DisciplineId = updatedGrade.DisciplineId;

            _dbContext.Grades.Update(existingGrade);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return existingGrade;
        }
    }
}

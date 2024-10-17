using Microsoft.EntityFrameworkCore;
using PetaevDanilKt_31_21.Database;
using PetaevDanilKt_31_21.Interfaces.StudentInterfaces;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Models.RequestDto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetaevDanilKt_31_21.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "students")
                .Options;
        }

        [Fact]
        public async Task AddGradeByStudentAsync_KT3121_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var gradeService = new GradeService(ctx);
            var students = new List<Student>
            {
                new Student
                {
                    Id = 4
                }
            };

            await ctx.Set<Student>().AddRangeAsync(students);

            var disciplines = new List<Discipline>
            {
                new Discipline
                {
                    DisciplineName = "Физика",
                    IsHumanities = false,
                    IsTechnical = true
                },
                new Discipline
                {
                    DisciplineName = "Программирование",
                    IsHumanities = false,
                    IsTechnical = true
                }
            };
            await ctx.Set<Discipline>().AddRangeAsync(disciplines);

            await ctx.SaveChangesAsync();

            // Act
            var grade1 = new AddGradeDto
            {
                Score = 2,
                StudentId = 4,
                DisciplineId = 2
            };

            var studentsResult = await gradeService.AddGradeByStudent(4, grade1, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Score);
            Assert.Equal(4, studentsResult.StudentId);
            Assert.Equal(2, studentsResult.DisciplineId);
        }
    }
}

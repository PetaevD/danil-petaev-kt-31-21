using Microsoft.AspNetCore.Mvc;
using PetaevDanilKt_31_21.Interfaces.StudentInterfaces;
using PetaevDanilKt_31_21.Models.RequestDto;

namespace PetaevDanilKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly ILogger<GradeController> _logger;
        private readonly IGradeService _gradeService;

        public GradeController(
            ILogger<GradeController> logger,
            IGradeService gradeService)
        {
            _logger = logger;
            _gradeService = gradeService;
        }

        [HttpPost("AddGradeByStudent/{studentId}")]
        public async Task<IActionResult> AddGradeByStudent([FromRoute] int studentId, [FromBody] AddGradeDto newGrade, CancellationToken cancellationToken = default)
        {
            try
            {
                await _gradeService.AddGradeByStudent(studentId, newGrade, cancellationToken);

                return Ok("Оценка успешно добавлена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");

                return BadRequest(ex);
            }
 
        }

        [HttpPost("ChangeGradeByStudent/{studentId}/{gradeId}")]
        public async Task<IActionResult> ChangeGradeByStudent([FromRoute] int studentId, [FromRoute] int gradeId, [FromBody] ChangeGradeDto updatedGrade, CancellationToken cancellationToken = default)
        {
            try
            {
                await _gradeService.ChangeGradeByStudent(studentId, gradeId, updatedGrade, cancellationToken);

                return Ok("Оценка успешно изменена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");

                return BadRequest(ex.Message);
            }
        }
    }
}

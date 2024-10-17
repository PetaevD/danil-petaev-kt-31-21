using Microsoft.AspNetCore.Mvc;
using PetaevDanilKt_31_21.Interfaces.StudentInterfaces;
using PetaevDanilKt_31_21.Models.RequestDto;

namespace PetaevDanilKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;

        public GroupController(
            ILogger<GroupController> logger,
            IGroupService groupService)
        {
            _logger = logger;
            _groupService = groupService;
        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroup([FromBody] AddGroupDto group, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.AddGroup(group, cancellationToken);

                return Ok("Группа успешно добавлена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");

                return BadRequest(ex);
            }

        }

        [HttpPost("ChangeGroup/{groupId}")]
        public async Task<IActionResult> ChangeGroup([FromRoute] int groupId, ChangeGroupDto changeGroup, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.ChangeGroup(groupId, changeGroup, cancellationToken);

                return Ok("Группа успешно изменена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteGroup/{groupId}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int groupId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _groupService.DeleteGroup(groupId, cancellationToken);

                return Ok("Группа успешно удалена.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error!");

                return BadRequest(ex.Message);
            }
        }
    }
}

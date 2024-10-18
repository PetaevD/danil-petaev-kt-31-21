using Microsoft.AspNetCore.Mvc;
using PetaevDanilKt_31_21.Interfaces.StudentInterfaces;
using PetaevDanilKt_31_21.Models.RequestDto;

namespace PetaevDanilKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost("AddGroup")]
        public async Task<IActionResult> AddGroup([FromBody] AddGroupDto group, CancellationToken cancellationToken = default)
        {
            await _groupService.AddGroup(group, cancellationToken);

            return Ok("Группа успешно добавлена.");
        }

        [HttpPost("ChangeGroup/{groupId}")]
        public async Task<IActionResult> ChangeGroup([FromRoute] int groupId, ChangeGroupDto changeGroup, CancellationToken cancellationToken = default)
        {
            await _groupService.ChangeGroup(groupId, changeGroup, cancellationToken);

            return Ok("Группа успешно изменена.");
        }

        [HttpDelete("DeleteGroup/{groupId}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int groupId, CancellationToken cancellationToken = default)
        {
            await _groupService.DeleteGroup(groupId, cancellationToken);

            return Ok("Группа успешно удалена.");
        }
    }
}

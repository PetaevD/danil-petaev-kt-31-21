using PetaevDanilKt_31_21.Database;
using PetaevDanilKt_31_21.Models;
using PetaevDanilKt_31_21.Models.RequestDto;
using Microsoft.EntityFrameworkCore;

namespace PetaevDanilKt_31_21.Interfaces.StudentInterfaces
{
    public interface IGroupService
    {
        public Task<Group> AddGroup(AddGroupDto group, CancellationToken cancellationToken);
        public Task<Group> ChangeGroup(int groupId, ChangeGroupDto changeGroup, CancellationToken cancellationToken);
        public Task<Group> DeleteGroup(int groupId, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        private readonly StudentDbContext _dbContext;

        public GroupService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group> AddGroup(AddGroupDto group, CancellationToken cancellationToken)
        {
            var newGroup = new Group
            {
                GroupName = group.Name,
                Speciality = group.Speciality,
                StartYear = group.StartYear,
                YearGraduation = group.YearGraduation,
                IsDeleted = group.IsDeleted
            };

            await _dbContext.Groups.AddAsync(newGroup, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newGroup;
        }

        public async Task<Group> ChangeGroup(int groupId, ChangeGroupDto changeGroup, CancellationToken cancellationToken)
        {
            var existingGroup = await _dbContext.Groups.FirstOrDefaultAsync(g => g.Id == groupId, cancellationToken);

            if (existingGroup == null)
            {
                throw new Exception("Группа не найдена.");
            }

            existingGroup.GroupName = changeGroup.Name;
            existingGroup.Speciality = changeGroup.Speciality;
            existingGroup.StartYear = changeGroup.StartYear;
            existingGroup.YearGraduation = changeGroup.YearGraduation;
            existingGroup.IsDeleted = changeGroup.IsDeleted;

            _dbContext.Groups.Update(existingGroup);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return existingGroup;
        }

        public async Task<Group> DeleteGroup(int groupId, CancellationToken cancellationToken)
        {
            var existingGroup = await _dbContext.Groups.FirstOrDefaultAsync(g => g.Id == groupId, cancellationToken);

            if (existingGroup == null)
            {
                throw new Exception("Группа не найдена.");
            }

            existingGroup.IsDeleted = true;

            _dbContext.Groups.Update(existingGroup);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return existingGroup;
        }
    }
}

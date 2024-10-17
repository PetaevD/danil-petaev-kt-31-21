using System.Text.RegularExpressions;
using Xunit;

namespace PetaevDanilKt_31_21.Tests
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public bool IsVaidGroupName()
        {
            return Regex.Match(GroupName, @"/\D*-\d*-\d\d/g").Success;
        }
    }

    public class GroupTests
    {
        [Fact]
        public void IsValidGroupName_KT3121_True()
        {
            var testGroup = new Group
            {
                GroupName = "สา-31-21"
            };

            var result = testGroup.IsVaidGroupName();

            Assert.True(result);
        }
    }
}
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "white"
            };
            app.GroupHelper.Add(newGroup);
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

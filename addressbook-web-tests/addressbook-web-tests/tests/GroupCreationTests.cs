using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : SessionBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test");
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData(group.Name, group.Header, group.Footer));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        //[Test, TestCaseSource("RandomGroupDataProvider")]
        //public void GroupCreationTest(GroupData group)
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData("a'a"));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }
    }
}
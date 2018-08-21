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
            GroupData group = new GroupData("test", "test", "test");
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData("test", "test", "test"));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            app.GroupHelper.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(new GroupData(""));
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
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
    }
}
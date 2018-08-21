using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeletionTests : SessionBase
    {
        [Test]
        public void TheGroupDeletionTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            app.GroupHelper.Delete(0);
            Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            
        }
    }
}

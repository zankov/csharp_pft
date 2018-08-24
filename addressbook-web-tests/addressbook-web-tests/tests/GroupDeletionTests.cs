﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeletionTests : GroupTestBase
    {
        [Test]
        public void TheGroupDeletionTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.GroupHelper.Delete(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
            
        }
    }
}

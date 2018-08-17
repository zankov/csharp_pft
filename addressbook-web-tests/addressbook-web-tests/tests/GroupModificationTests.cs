using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("new", "new", "new");
            app.GroupHelper.Modify(1, group);
        }       
    }
}

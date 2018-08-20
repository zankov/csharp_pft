using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : SessionBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("new",null, null);
            app.GroupHelper.Modify(1, group);
        }       
    }
}

using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : SessionBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test", "test", "test");            
            app.GroupHelper.Create(group);               
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.GroupHelper.Create(group);
        }
    }
}
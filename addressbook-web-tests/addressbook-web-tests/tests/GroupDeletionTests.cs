using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TheGroupDeletionTest()
        {
            app.GroupHelper.Delete(1);
        }
    }
}

using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupDeletionTests : SessionBase
    {
        [Test]
        public void TheGroupDeletionTest()
        {
            app.GroupHelper.Delete(1);
        }
    }
}

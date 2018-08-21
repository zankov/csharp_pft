using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : SessionBase
    {
        [Test]
        public void SearchTest()
        {
            System.Console.Out.Write(app.ContactHelper.GetNumberOfSearchResults());
        }
    }
}

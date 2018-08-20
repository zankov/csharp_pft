using NUnit.Framework;

namespace WebAddressbookTests
{
    public class SessionBase : TestBase
    {
        [SetUp]
        public void SetupSession()
        {
            app.SessionHelper.Login(new AccountData("admin", "secret"));
        }
    }
}

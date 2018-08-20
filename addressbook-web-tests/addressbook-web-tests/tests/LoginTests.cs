using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.SessionHelper.Logout();
            AccountData account = new AccountData("admin", "secret");
            app.SessionHelper.Login(account);
            Assert.IsTrue(app.SessionHelper.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.SessionHelper.Logout();
            AccountData account = new AccountData("admin", "123456");
            app.SessionHelper.Login(account);
            Assert.IsFalse(app.SessionHelper.IsLoggedIn(account));
        }
    }
}

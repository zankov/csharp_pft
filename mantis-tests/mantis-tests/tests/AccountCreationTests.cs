using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void SetUpConfig()
        {
            app.FtpHelper.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open(Path.Combine(TestContext.CurrentContext.WorkDirectory, @"config_inc.php"), FileMode.Open))
            {
                app.FtpHelper.Upload("/config_inc.php", localFile);
            }  
        }
        [Test]
        public void AccountCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            app.RegistrationHelper.Register(account);
        }
        [OneTimeTearDown]
        public void RestoreConfig()
        {
            app.FtpHelper.RestoreBackupFile("/config_inc.php");
        }
    }
}

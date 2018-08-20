using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class TestBase
    {
        public ApplicationManager app;
        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}

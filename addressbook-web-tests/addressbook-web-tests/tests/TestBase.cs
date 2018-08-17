using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {               
        public ApplicationManager app;        
        [SetUp]
        public void SetupTest()
        {            
            app = new ApplicationManager();
            app.NavigationHelper.OpenHomePage();
            app.SessionHelper.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void TeardownTest()
        {
            app.SessionHelper.Logout();
            app.Stop();
        }
    }
}

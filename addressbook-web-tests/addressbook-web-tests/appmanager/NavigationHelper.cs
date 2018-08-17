using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager)
            : base(manager)
        {
            this.baseURL = manager.BaseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}

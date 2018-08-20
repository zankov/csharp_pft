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
            if (!(driver.Url == baseURL + "/addressbook/"))
            {
                driver.Navigate().GoToUrl(baseURL + "/addressbook/");
            }   
        }
        public void GoToGroupsPage()
        {
            if (!(driver.Url == baseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new"))))
            {
                driver.FindElement(By.LinkText("groups")).Click();
            }
        }
    }
}

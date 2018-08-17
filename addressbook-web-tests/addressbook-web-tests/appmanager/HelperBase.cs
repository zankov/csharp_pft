using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class HelperBase
    {
        public IWebDriver driver;
        public ApplicationManager manager;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
    }
}
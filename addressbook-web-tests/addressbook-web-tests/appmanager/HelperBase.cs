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
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }            
        }
    }
}
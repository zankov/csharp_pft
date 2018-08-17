using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;
        public GroupHelper groupHelper;
        public NavigationHelper navigationHelper;
        public SessionHelper sessionHelper;
        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8088";
            groupHelper = new GroupHelper(this);
            navigationHelper = new NavigationHelper(this);
            sessionHelper = new SessionHelper(this);           
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }
        public GroupHelper GroupHelper
        {
            get
            {
                return groupHelper;
            }
        }
        public NavigationHelper NavigationHelper
        {
            get
            {
                return navigationHelper;
            }
        }
        public SessionHelper SessionHelper
        {
            get
            {
                return sessionHelper;
            }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }        
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        private IWebDriver driver;
        private string baseURL;
        public ContactHelper contactHelper;
        public GroupHelper groupHelper;
        public NavigationHelper navigationHelper;
        public SessionHelper sessionHelper;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:8088";
            contactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);
            navigationHelper = new NavigationHelper(this);
            sessionHelper = new SessionHelper(this);           
        }
        ~ApplicationManager()
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
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.NavigationHelper.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
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
        public ContactHelper ContactHelper
        {
            get
            {
                return contactHelper;
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
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }
        public GroupHelper Create(GroupData group)
        {
            manager.NavigationHelper.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Modify(int index, GroupData group)
        {
            manager.NavigationHelper.GoToGroupsPage();
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Delete(int index)
        {
            manager.NavigationHelper.GoToGroupsPage();
            SelectGroup(index);
            DeleteSelectedGroups();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        private void InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public GroupHelper DeleteSelectedGroups()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {

            }
            groupCache = new List<GroupData>();
            manager.NavigationHelper.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.ClassName("group"));
            foreach (IWebElement element in elements)
            {
                groupCache.Add(new GroupData(element.Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return new List<GroupData>(groupCache);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            driver = manager.Driver;
        }

        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.XPath("//span[@class='group']")))
            {
                GroupData group = new GroupData("NewTestGroup");
                group.Header = "NewTestHeader";
                group.Footer = "NewTestFooter";
                Create(group);
            }
                         
                SelectGroup(v);
                DeleteGroup();
                ReturnToGroupsPage();
        
            return this;
        }

        public GroupHelper Modify(int v, GroupData newGroup)
        {
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.XPath("//span[@class='group']")))
            {
                GroupData group = new GroupData("NewTestGroup");
                group.Header = "NewTestHeader";
                group.Footer = "NewTestFooter";
                Create(group);
            }
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newGroup);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

         

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        
    }
}

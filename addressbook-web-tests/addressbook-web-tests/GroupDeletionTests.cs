using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        
        [Test]
        public void TheGroupDeletionTestsTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();

        }

        

    }
}

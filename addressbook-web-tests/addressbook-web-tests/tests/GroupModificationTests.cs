using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [SetUp]
        public void TestPresentAnyGroups()
        {
            CreateGroupIfNothing();
        }

        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("TestGroupNew");
            newGroup.Header = "TestHeaderNew";
            newGroup.Footer = "TestFooterNew";

            app.Groups.Modify(1, newGroup);
        }
    }
}

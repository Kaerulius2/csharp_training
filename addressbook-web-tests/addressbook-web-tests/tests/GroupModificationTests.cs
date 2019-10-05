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
            GroupData newGroup = app.Groups.FillGroupData("TestGroupNew", "TestHeaderNew", "TestFooterNew");

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newGroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            oldGroups[0].Name = newGroup.Name;
            oldGroups[0].Header = newGroup.Header;
            oldGroups[0].Footer = newGroup.Footer;

            List <GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

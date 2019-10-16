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
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified, newGroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            oldGroups[0].Name = newGroup.Name;
            oldGroups[0].Header = newGroup.Header;
            oldGroups[0].Footer = newGroup.Footer;

            List <GroupData> newGroups = GroupData.GetAll();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

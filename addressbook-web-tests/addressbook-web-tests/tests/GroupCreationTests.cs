using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {        
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("TestGroup");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("TestGroup");
            group.Header = "";
            group.Footer = "";
                        
            app.Groups.Create(group);

        }




    }
}

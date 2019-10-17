using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : Testbase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "Test"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(newGroup);

            newGroups.Sort();
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

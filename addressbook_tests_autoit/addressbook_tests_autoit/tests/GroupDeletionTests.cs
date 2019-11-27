using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : Testbase
    {
        [Test]
        public void TestGroupDeletion()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();


            if (oldGroups.Count <= 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "NewGroup"
                };

                app.Groups.Add(newGroup);
                oldGroups.Add(newGroup);
            }

            GroupData groupToDelete = oldGroups[0];

            app.Groups.Delete(groupToDelete);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(groupToDelete);

            newGroups.Sort();
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}

﻿using System;
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
            GroupData group = app.Groups.FillGroupData("TestGroup","TestHeader","TestFooter");
                
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

            oldGroups.Add(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        

        /*
       [Test]
       public void BadNameGroupCreationTest()
       {
           GroupData group = new GroupData("a'a");
           group.Header = "TestHeader";
           group.Footer = "TestFooter";

           List<GroupData> oldGroups = app.Groups.GetGroupList();

           app.Groups.Create(group);

   Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

           oldGroups.Add(group);
           List<GroupData> newGroups = app.Groups.GetGroupList();
           oldGroups.Sort();
           newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);

       }
       */
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("TestGroup");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }




    }
}

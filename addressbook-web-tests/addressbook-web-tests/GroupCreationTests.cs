﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {        
        [Test]
        public void GroupCreationTest()
        {

            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("TestGroup");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            navigationHelper.ReturnToGroupsPage();

        }

        

        
                 
       
    }
}

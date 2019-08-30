using System;
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

            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("TestGroup");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

        }

        

        
                 
       
    }
}

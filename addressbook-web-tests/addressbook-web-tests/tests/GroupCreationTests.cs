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

            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("TestGroup");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();

        }

        

        
                 
       
    }
}

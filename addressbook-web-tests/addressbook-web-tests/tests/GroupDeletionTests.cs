using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        
        [Test]
        public void TheGroupDeletionTestsTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.DeleteGroup();
            app.Navigator.ReturnToGroupsPage();

        }

        

    }
}

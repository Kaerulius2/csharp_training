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
            GroupData group = new GroupData("TestGroup");
            group.Header = "TestHeader";
            group.Footer = "TestFooter";
                        
            app.Groups.Create(group);

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

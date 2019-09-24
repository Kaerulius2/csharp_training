using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupDeletionTests : AuthTestBase
    {
        [SetUp]
        public void TestPresentAnyGroups()
        {
            CreateGroupIfNothing();
        }

        [Test]
        public void TheGroupDeletionTestsTest()
        {
                app.Groups.Remove(1);
            
        }

        

    }
}

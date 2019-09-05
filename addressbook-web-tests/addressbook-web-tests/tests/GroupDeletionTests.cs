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
            app.Groups.Remove(1);
            
        }

        

    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactDeletionTests : AuthTestBase
    {

        [SetUp]
        public void TestPresentAnyContacts()
        {
            CreateContactIfNothing();
        }

        [Test]
        public void TheUserDelertionTest()
        {
            app.Contacts.Delete(1);
            
        }

        

        
        
    }
}

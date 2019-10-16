using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

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
            List<ContactData> oldCont = ContactData.GetAll();

            ContactData toBeRemoved = oldCont[0];

            app.Contacts.Delete(toBeRemoved);

            Assert.AreEqual(oldCont.Count - 1, app.Contacts.GetContactCount());

            oldCont.RemoveAt(0);

            List<ContactData> newCont = ContactData.GetAll();

            oldCont.Sort();
            newCont.Sort();

            Assert.AreEqual(oldCont, newCont);
        }

        

        
        
    }
}

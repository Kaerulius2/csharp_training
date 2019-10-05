using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationsTests : AuthTestBase
    {
        
        [Test]
        public void TheUserCreationsTestsTest()
        {
            ContactData contact = app.Contacts.FillContactForm("Alex", "Ivanoff", "Ivanovitch", "100111 Russia, MSK, Tverskaya str 61-2", "alex@mail.com", "+79260005544");

            List<ContactData> oldCont = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldCont.Count + 1, app.Contacts.GetContactCount());

            oldCont.Add(contact);
            List<ContactData> newCont = app.Contacts.GetContactList();

            oldCont.Sort();
            newCont.Sort();

            Assert.AreEqual(oldCont, newCont);
        }

        

        
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void TestPresentAnyContacts()
        {
            CreateContactIfNothing();
        }

        [Test]
        public void UserModificationTest()
        {
            ContactData contactNew = app.Contacts.FillContactForm("Boris", "Petroff", "Kirillovitch", "100111 Russia, SPb, Nevskiy str 6-32", "boriss@mail.com", "+79260003344");


            List<ContactData> oldCont = ContactData.GetAll();

            ContactData toBeModified = oldCont[0];

            app.Contacts.Modify(toBeModified, contactNew);

            Assert.AreEqual(oldCont.Count, app.Contacts.GetContactCount());

            oldCont[0].Firstname = contactNew.Firstname;
            oldCont[0].Lastname = contactNew.Lastname;
            oldCont[0].Middlename = contactNew.Middlename;
            oldCont[0].Address = contactNew.Address;
            oldCont[0].Email = contactNew.Email;
            oldCont[0].Homephone = contactNew.Homephone;

            List<ContactData> newCont = ContactData.GetAll();

            oldCont.Sort();
            newCont.Sort();

            Assert.AreEqual(oldCont, newCont);
        }

        
    }
}

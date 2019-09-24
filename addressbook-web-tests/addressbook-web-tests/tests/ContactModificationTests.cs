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
            ContactData contactNew = new ContactData("Boris", "Petroff");
            contactNew.Middlename = "Kirillovitch";
            contactNew.Address = "100111 Russia, SPb, Nevskiy str 6-32";
            contactNew.Email = "boriss@mail.com";
            contactNew.Homephone = "+79260003344";

            List<ContactData> oldCont = app.Contacts.GetContactList();

            app.Contacts.Modify(0, contactNew);

            oldCont[0].Firstname = contactNew.Firstname;
            oldCont[0].Lastname = contactNew.Lastname;
            oldCont[0].Middlename = contactNew.Middlename;
            oldCont[0].Address = contactNew.Address;
            oldCont[0].Email = contactNew.Email;
            oldCont[0].Homephone = contactNew.Homephone;

            List <ContactData> newCont = app.Contacts.GetContactList();

            oldCont.Sort();
            newCont.Sort();

            Assert.AreEqual(oldCont, newCont);
        }

        

        
        
    }
}

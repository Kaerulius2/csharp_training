﻿using System;
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
            List<ContactData> oldCont = app.Contacts.GetContactList();

            app.Contacts.Delete(0);

            oldCont.RemoveAt(0);
            List<ContactData> newCont = app.Contacts.GetContactList();

            oldCont.Sort();
            newCont.Sort();

            Assert.AreEqual(oldCont, newCont);
        }

        

        
        
    }
}

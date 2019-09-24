﻿using System;
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
            ContactData contact = new ContactData("Alex", "Ivanoff");
            contact.Middlename = "Ivanovitch";
            contact.Address = "100111 Russia, Moscow, Tvetskaya str 123-54";
            contact.Email = "alexxx@mail.com";
            contact.Homephone = "+79260001122"; 

            app.Contacts.Create(contact);
            
        }

        

        
        
    }
}

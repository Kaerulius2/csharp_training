using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        
        [Test]
        public void UserModificationTest()
        {
            ContactData contactNew = new ContactData("Boris", "Petroff");
            contactNew.Middlename = "Kirillovitch";
            contactNew.Address = "100111 Russia, SPb, Nevskiy str 6-32";
            contactNew.Email = "boriss@mail.com";
            contactNew.Homephone = "+79260003344";

            app.Contacts.Modify(1, contactNew);
            
            
        }

        

        
        
    }
}

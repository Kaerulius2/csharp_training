using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationsTests : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> cont = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                cont.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(20))
                {
                    Address = GenerateRandomString(150),
                    Homephone = GenerateRandomString(10),
                    Workphone = GenerateRandomString(10),
                    Mobilephone = GenerateRandomString(10),
                    Email = GenerateRandomString(50),
                    Email2 = GenerateRandomString(50),
                    Email3 = GenerateRandomString(50)
                });
            }

            return cont;
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
               new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void TheUserCreationsTestsTest(ContactData contact)
        {
            //ContactData contact = app.Contacts.FillContactForm("Alex", "Ivanoff", "Ivanovitch", "100111 Russia, MSK, Tverskaya str 61-2", "alex@mail.com", "+79260005544");

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

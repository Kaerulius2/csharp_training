using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AddingContactToGroupTests :AuthTestBase
    {
        [SetUp]
        public void ensurePreconditions()
        {
            //проверим, что есть хоть одна группа и контакт, если нет - создать
            
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.CreateNewGroup();
            }
            if (ContactData.GetAll().Count == 0)
            {
                app.Contacts.CreateNewContact();
            }

        }

        [Test]
        public void TestAddingContactToGroup()
        {
            ContactData contact;
            //берем произвольную группу
            GroupData group = GroupData.GetAll()[0];
            //получим список состоящих в ней контактов
            List<ContactData> oldList = group.GetContacts();
            //получим список не состоящих в ней контактов
            List<ContactData> availCont = ContactData.GetAll().Except(oldList).ToList();
            //если нет - создадим новый
            if (availCont.Count == 0)
            {
                app.Contacts.CreateNewContact();
                contact = ContactData.GetAll().Except(oldList).First();
            }
            else
            {
                contact = availCont.First();
            }
                    

            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

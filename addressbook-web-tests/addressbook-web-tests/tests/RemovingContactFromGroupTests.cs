using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class RemovingContactFromGroupTests : AuthTestBase
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
        public void TestRemovingContactFromGroup()
        {
            GroupData group;
            //возьмем контакт
            ContactData contact = ContactData.GetAll()[0];
            //получим его группы
            List<GroupData> oldList = contact.GetGroups();
            
                        
            //если контакт не состоит ни в одной, добавим его в какую-нибудь
            if (oldList.Count==0)
            {
                group = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(contact, group);
                oldList.Add(group);
            }
            else // а если состоит - возьмем первую
            {
                group = oldList.First();
            }
            
            //удалим контакт из группы
            app.Contacts.RemoveContactFromGroup(contact, group);

            //сравним старый и новый списки групп
            List<GroupData> newList = contact.GetGroups();
            oldList.Remove(group);            
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

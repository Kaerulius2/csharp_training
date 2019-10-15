using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_TEST = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationMAnager()
        {
            app = ApplicationManager.GetInstance();
            
        }
         
        public void CreateGroupIfNothing()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.XPath("//span[@class='group']")))
            {
                GroupData group = new GroupData("NewTestGroup");
                group.Header = "NewTestHeader";
                group.Footer = "NewTestFooter";
                app.Groups.Create(group);
            }
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i <l; i++)
            {
               builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();

        }

        public void CreateContactIfNothing()
        {
            app.Navigator.ReturnToHomepage();
            if (!app.Contacts.IsElementPresent(By.XPath("//img[@title='Edit']")))
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

}


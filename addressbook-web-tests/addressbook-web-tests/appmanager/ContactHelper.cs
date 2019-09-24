using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            
        }

        public ContactHelper Delete(int v)
        {
            manager.Navigator.ReturnToHomepage();
            SelectContact(v);
            DeleteContact();
            CloseAlert();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public ContactHelper Modify(int v, ContactData contactNew)
        {
            manager.Navigator.ReturnToHomepage();
            InitContactModification(v);
            FillNewContactForm(contactNew);
            SubmitContactModify();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + index + "]")).Click();
            return this;
        }

        private ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            return this;
        }

        private ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        private ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper FillNewContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Homephone);
            Type(By.Name("email"), contact.Email);
                        
            return this;
        }

        

        internal ContactHelper Create(ContactData contact)
        {
            OpenNewContactForm();
            FillNewContactForm(contact);
            SubmitContactForm();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public ContactHelper OpenNewContactForm()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
    }
}

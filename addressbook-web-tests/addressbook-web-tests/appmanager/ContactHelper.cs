using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        internal void CreateNewContact()
        {
            ContactData contact = new ContactData("Alex", "Ivanoff");
            contact.Middlename = "Ivanovitch";
            contact.Address = "100111 Russia, Moscow, Tvetskaya str 123-54";
            contact.Email = "alexxx@mail.com";
            contact.Homephone = "+79260001122";

            Create(contact);
            
        }

        public ContactHelper Delete(ContactData contact)
        {
            manager.Navigator.ReturnToHomepage();
            SelectContact(contact.Id);
            DeleteContact();
            CloseAlert();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.ReturnToHomepage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Id);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0); 
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string id)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByValue(id);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");    
        }

        public ContactData GetInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(index);

            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstname.Trim(), lastname.Trim())
            {
                Middlename = middlename,
                Address = address,
                Homephone = homePhone,
                Mobilephone = mobilePhone,
                Workphone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
                           
            };

        }

        internal void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.ReturnToHomepage();
            SelectGroupByFilter(group.Id);
            SelectContact(contact.Id);
            CommitRemovingContact();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContact()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupByFilter(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(id);
        }

        public string GetInformationFromProp(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenContactProperty(index);
            string text = driver.FindElement(By.Id("content")).GetAttribute("innerText");
            return text.Trim();
        }

        public ContactData GetInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails

            };
        }

        public int GetNumberOfResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
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
        public ContactHelper Modify(ContactData oldContact, ContactData contactNew)
        {
            manager.Navigator.ReturnToHomepage();
            InitContactModification(oldContact.Id);
            FillNewContactForm(contactNew);
            SubmitContactModify();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public ContactData FillContactForm(string firstname, string lastname, string midname, string address, string email, string homephone)
        {
            ContactData contactNew = new ContactData(firstname, lastname);
            contactNew.Middlename = midname;
            contactNew.Address = address;
            contactNew.Email = email;
            contactNew.Homephone = homephone;

            return contactNew;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        private List<ContactData> contCache = null;

        public List<ContactData> GetContactList()
        {
            if (contCache == null)
            {
                contCache = new List<ContactData>();
                manager.Navigator.ReturnToHomepage();

                ICollection<IWebElement> entries = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (IWebElement el in entries)
                {
                    IList<IWebElement> cells = el.FindElements(By.TagName("td"));
                    String id = cells[0].FindElement(By.TagName("input")).GetAttribute("value");
                    ContactData con = new ContactData(id,cells[2].Text, cells[1].Text);
                    contCache.Add(con);
                }
            }
                       
            return new List<ContactData>(contCache);
        }

        public ContactHelper OpenContactProperty(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Details'])[" + (index + 1) + "]")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index+1) + "]")).Click();
            return this;
        }

        private ContactHelper InitContactModification(string index)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + index + "']")).Click();
            return this;
        }

        private ContactHelper SubmitContactModify()
        {
            driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            contCache = null;
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
            contCache = null;
            return this;
        }

        public ContactHelper SubmitContactForm()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contCache = null;
            return this;
        }

        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
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

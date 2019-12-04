using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        private string baseURL;

        public LoginHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenLoginPage()
        {
            if (driver.Url == baseURL + "/login_page.php")
            {
                return;
            }

            driver.Navigate().GoToUrl(baseURL + "/login_page.php");
        }

        
        private bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//td[@class='login-info-left']"));
        }

        private bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && GetLogUserName() == account.Name;
        }

        private string GetLogUserName()
        {
            return driver.FindElement(By.XPath("//td[@class='login-info-left']/span")).Text;
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("username"), account.Name);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.XPath("//*[@type='submit']")).Click();
        }

    }
}

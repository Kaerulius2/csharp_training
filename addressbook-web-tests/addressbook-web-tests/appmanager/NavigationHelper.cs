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
    public class NavigationHelper : HelperBase
    {

        private IWebDriver driver;
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            driver = manager.Driver;
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void ReturnToHomepage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void GoToGroupsPage()
        {
            if ((driver.Url == baseURL+"group.php") && (IsElementPresent(By.Name("new")))){
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }

        

    }
}

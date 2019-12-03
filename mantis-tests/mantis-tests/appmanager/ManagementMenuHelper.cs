using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        private string baseURL;
        public ManagementMenuHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenManageProjectPage()
        {
            if (driver.Url == baseURL + "/manage_proj_page.php")
            {
                return;
            }

            driver.FindElement(By.LinkText("Manage")).Click();
            driver.FindElement(By.LinkText("Manage Projects")).Click();
        }

    }
}

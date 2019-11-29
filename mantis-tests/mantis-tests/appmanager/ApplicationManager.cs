using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using static System.Net.WebRequestMethods;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public FtpHelper Ftp { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
          
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.Navigator.OpenHomePage();
                newInstance.driver.Url = "http://localhost/mantisbt-1.2.19/login_page.php";
                app.Value = newInstance;
                
            }
            return app.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

        }

        

       

        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }
        
    }
}

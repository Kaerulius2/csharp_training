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
        public AdminHelper Admin { get; set; }
        public APIHelper API { get;  set; }
        public LoginHelper Login { get; set; }

        public ManagementMenuHelper Menu { get; set; }
        public ProjectManagementHelper Project { get; set; }

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/mantisbt-1.2.17";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Admin = new AdminHelper(this, baseURL);
            API = new APIHelper(this);
            Project = new ProjectManagementHelper(this);
            Menu = new ManagementMenuHelper(this, baseURL);
            Login = new LoginHelper(this, baseURL);
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                //newInstance.Navigator.OpenHomePage();
                newInstance.driver.Url = newInstance.baseURL + "/login_page.php";
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

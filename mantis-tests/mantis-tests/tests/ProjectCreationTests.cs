using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class ProjectCreationTests : TestBase
    {
        [SetUp]
        public void DeleteTestProject()
        {
            //удалим проект, если такой уже есть
            app.Driver.FindElement(By.Name("username")).SendKeys("administrator");
            app.Driver.FindElement(By.Name("password")).SendKeys("root");
            app.Driver.FindElement(By.XPath("//*[@type='submit']")).Click();
            app.Project.DeleteProjectIfExist(new ProjectData("test"));
        }

        [Test]
        public void CreateProjectTests()
        {
            //удалим проект, если такой уже есть
            
        }
    }
}

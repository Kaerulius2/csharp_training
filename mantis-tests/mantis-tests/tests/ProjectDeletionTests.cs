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
    public class ProjectDeletionTests : TestBase
    {
        [SetUp]
        public void CreateTestProject()
        {
            //удалим создадим проект, если ни одного нет
            //проверим, что залогинены, если нет - логинимся
            AccountData acc = new AccountData() { Name = "administrator", Password = "root" };
            app.Login.Login(acc);
            //app.Project.CreateProjectIfNothing(project);
            app.API.CreateProjectIfNothing(acc);
        }

        [Test]
        public void DeleteProjectTests()
        {
            AccountData acc = new AccountData() { Name = "administrator", Password = "root" };
            List<ProjectData> oldProjects = app.API.GetProjectsList(acc);

            int index = 0; //удалять будем первый элемент

            app.Project.RemoveProject(index+1);
                        
            List<ProjectData> newProjects = app.API.GetProjectsList(acc);

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(index);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

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
            app.Login.Login(new AccountData() { Name = "administrator", Password = "root" });
            ProjectData project = new ProjectData("test")
            {
                Status = "development",
                ViewStatus = "public",
                Description = "Test loooooooooong description!!!",
                Enabled = "true"
            };
            app.Project.CreateProjectIfNothing(project);
        }

        [Test]
        public void DeleteProjectTests()
        {

            List<ProjectData> oldProjects = app.Project.GetProjectsList();

            int index = 0; //удалять будем первый элемент

            app.Project.RemoveProject(index+1);
                        
            List<ProjectData> newProjects = app.Project.GetProjectsList();

            Assert.AreEqual(oldProjects.Count - 1, newProjects.Count);

            oldProjects.RemoveAt(index);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

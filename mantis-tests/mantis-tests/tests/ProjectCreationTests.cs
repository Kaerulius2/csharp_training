﻿using System;
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
            //Залогинимся и удалим проект, если такой уже есть
            app.Login.Login(new AccountData() { Name = "administrator", Password = "root" });
            app.Project.DeleteProjectIfExist(new ProjectData("test"));
        }

        [Test]
        public void CreateProjectTests()
        {

            List<ProjectData> oldProjects = app.Project.GetProjectsList();

            ProjectData project = new ProjectData("test")
            {
                Status = "development",
                ViewStatus = "public",
                Description = "Test loooooooooong description!!!",
                Enabled = "true"
            };

            app.Project.Create(project);

            List<ProjectData> newProjects = app.Project.GetProjectsList();

            Assert.AreEqual(oldProjects.Count + 1, newProjects.Count);

            oldProjects.Add(project);

            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}

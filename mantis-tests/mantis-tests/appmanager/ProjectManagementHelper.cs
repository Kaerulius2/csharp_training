using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void InitProjectAdding()
        {
            driver.FindElement(By.XPath("//input[@value='Create New Project']")).Click();
        }

        public void RemoveProject(int index)
        {

            InitRemoving(index);
            SubmitRemoving();
                        
        }

        public void DeleteProjectIfExist(ProjectData project)
        {
            List<ProjectData> list = GetProjectsList();

            if (list.Count == 0)
                return;

            var indexOfExistProject = list.FindIndex(x => x.Name == project.Name);

            if (indexOfExistProject != -1)
            {
                RemoveProject(indexOfExistProject+1);
            }
        }

  

        public void CreateProjectIfNothing(ProjectData project)
        {
            if(GetProjectsList().Count == 0)
            {
                Create(project);
            }
        }

        public void FillProjectAddingForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
            Type(By.Name("description"), project.Description);
            SelectElement(By.Name("status"), project.Status);
            SelectElement(By.Name("view_state"), project.ViewStatus);
        }

        internal void Create(ProjectData project)
        {
            manager.Menu.OpenManageProjectPage();
            InitProjectAdding();
            FillProjectAddingForm(project);
            SubmitProjectCreation();

        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
            driver.FindElement(By.LinkText("Proceed")).Click();

        }

        public void InitRemoving(int index)
        {
            string xpa = @"//table[@class='width100' and @cellspacing='1']/tbody/tr[@class='row-1' or @class='row-2'][" + index + "]/td/a";
            driver.FindElement(By.XPath(xpa)).Click();
                                  
        }

        public void SubmitRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();

        }

        public List<ProjectData> GetProjectsList()
        {
            List<ProjectData> list = new List<ProjectData>();

            //открыть страницу с проектами
            manager.Menu.OpenManageProjectPage();
            //получить перечень строк таблицы
            ICollection<IWebElement> tableRows = driver.FindElements(By.XPath("//table[@class='width100' and @cellspacing='1']/tbody/tr[@class='row-1' or @class='row-2']"));

            if (tableRows.Count == 0)
            {
                return list;
            }

            foreach (IWebElement row in tableRows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                string name = cells[0].Text;
                string status = cells[1].Text;
                string enabled = "";
                if (cells[2].Text == " ")
                    enabled = "false";
                else
                    enabled = "true";
                string viewSt = cells[3].Text;
                string description = cells[4].Text;

                list.Add(new ProjectData(name)
                {
                    Status = status,
                    Enabled = enabled,
                    ViewStatus = viewSt,
                    Description = description
                });
            }

            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
       
        public APIHelper(ApplicationManager manager) : base(manager) {

                   
        }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        internal void CreateProjectIfNothing(AccountData account)
        {
            if (GetProjectsList(account).Count == 0)
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData project = new Mantis.ProjectData();

                project.name = new ProjectData("test").Name;

                client.mc_project_add(account.Name, account.Password, project);


            }
        }

        

        public List<ProjectData> GetProjectsList(AccountData account)
        {
            List<ProjectData> list = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);

            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    //Id = project.id,
                    Name = project.name,
                    Description = project.description,
                    Status = project.status.name,
                    Enabled = project.enabled.ToString(),
                    ViewStatus = project.view_state.name

                });
            }
            
            return list;
        }

    }
}

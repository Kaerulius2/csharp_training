using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {   
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for(int i=0; i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(90),
                    Footer = GenerateRandomString(90)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");

            foreach(string l in lines)
            {
                string[] parts = l.Split(';');
                groups.Add(new GroupData(parts[0]) {
                    Header = parts[1],
                    Footer = parts[2]
                });  
                                
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));

        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
    
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));
           
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            //GroupData group = app.Groups.FillGroupData("TestGroup","TestHeader","TestFooter");
                
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

            oldGroups.Add(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        

        /*
       [Test]
       public void BadNameGroupCreationTest()
       {
           GroupData group = new GroupData("a'a");
           group.Header = "TestHeader";
           group.Footer = "TestFooter";

           List<GroupData> oldGroups = app.Groups.GetGroupList();

           app.Groups.Create(group);

   Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

           oldGroups.Add(group);
           List<GroupData> newGroups = app.Groups.GetGroupList();
           oldGroups.Sort();
           newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);

       }
       */
        
        




    }
}

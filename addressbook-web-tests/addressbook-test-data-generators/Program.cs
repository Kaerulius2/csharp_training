using System;
using System.Collections.Generic;
using System.IO;
using addressbook_web_tests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

           
            if (type == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(20),
                        Footer = TestBase.GenerateRandomString(30)
                    });
                }

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.Out.Write("Unrecognized format: " + format);
                }

                writer.Close(); //обязательно закрывать файлы!
            }
            else if(type=="contacts")
            {
                List<ContactData> cont = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    cont.Add(new ContactData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(20))
                    {
                        Address = TestBase.GenerateRandomString(150),
                        Middlename = TestBase.GenerateRandomString(10),
                        Homephone = TestBase.GenerateRandomString(10),
                        Workphone = TestBase.GenerateRandomString(10),
                        Mobilephone = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(50),
                        Email2 = TestBase.GenerateRandomString(50),
                        Email3 = TestBase.GenerateRandomString(50)
                    });

                }

                    if (format == "xml")
                    {
                        writeContactsToXmlFile(cont, writer);
                    }                    
                    else if (format == "json")
                    {
                        writeContactsToJsonFile(cont, writer);
                    }
                    else
                    {
                        Console.Out.Write("Unrecognized format: " + format);
                    }

                
            }
            else
            {
                Console.Out.Write("Unrecognized type: " + type);
            }

            writer.Close(); //обязательно закрывать файлы!
        }

        static void writeContactsToJsonFile(List<ContactData> cont, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(cont, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<ContactData> cont, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, cont);
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData gr in groups)
            {
                writer.WriteLine(String.Format("{0};{1};{2}",
                    gr.Name, gr.Header, gr.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

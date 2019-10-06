using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname {get; set;}

        public string Lastname {get; set;}


        public string Middlename {get; set;}
        
        public string Address {get; set;}

        public string Homephone {get; set;}

        public string Mobilephone { get; set; }

        public string Workphone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllPhones {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Homephone) + CleanUp(Mobilephone) + CleanUp(Workphone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } 
        
        }

        public string CleanUp(string str)
        {
            if (str == null || str == "")
            {
                return "";
            }

            return str.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string AllData
        {
            get
            {
                if(allData != null)
                {
                    return allData;
                }

                string txt = String.Format("{0} {1} {2}\r\n{3}\r\n\r\nH: {4}\r\nM: {5}\r\nW: {6}\r\n\r\n{7}\r\n{8}\r\n{9}", 
                    Firstname, Middlename, Lastname, Address, Homephone, Mobilephone, Workphone, Email, Email2, Email3);
                return txt;
            }
            set
            {
                allData = value;
            }
        }

        public string AllEmails {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }

                return String.Format("{0}\r\n{1}\r\n{2}", Email, Email2, Email3).Trim();
                    
            }
            set
            {
                allEmails = value;
            } 
        
        }
            
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname==other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (Firstname == other.Firstname) && (Lastname == other.Lastname);

        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "LastName=" + Lastname + "\nFirstName=" + Firstname;
        }
    }
    
}

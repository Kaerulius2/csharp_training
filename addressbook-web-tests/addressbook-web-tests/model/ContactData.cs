using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_web_tests
{
    [Table(Name ="addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;

        public ContactData()
        {
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        [Column(Name = "id"),PrimaryKey]
        public string Id { get; set; }

        [Column(Name ="firstname")]
        public string Firstname {get; set;}

        [Column(Name = "lastname")]
        public string Lastname {get; set;}


        public string Middlename {get; set;}
        
        public string Address {get; set;}

        public string Homephone {get; set;}

        public string Mobilephone { get; set; }

        public string Workphone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        
        [Column(Name ="deprecated")]
        public string Deprecated { get; set; }

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

            //return Regex.Replace(str, " -()", "") + "\r\n";
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

                string fio = (IsData(Firstname) + IsData(Middlename) + IsData(Lastname)).Trim() + "\r\n";

                string addr = "";

                if (IsData(Address) != "")
                {
                    addr = IsData(Address).Trim() + "\r\n\r\n";
                }
                else
                {
                    addr = "\r\n";
                }
                

                string hph = "";
                string mph = "";
                string wph = "";

                if (IsData(Homephone) != "")
                {
                    hph = "H: " + IsData(Homephone).Trim() + "\r\n";
                }
                else
                {
                    hph = "";
                }

                if (IsData(Mobilephone) != "")
                {
                     mph = "M: " + IsData(Mobilephone).Trim() + "\r\n";
                }
                else
                {
                     mph = "";
                }

                if (IsData(Workphone) != "")
                {
                     wph = "W: " + IsData(Workphone).Trim() + "\r\n";
                }
                else
                {
                     wph = "";
                }
                               
                string phones = hph + mph + wph + "\r\n";
                if(phones == "\r\n")
                {
                    phones = "";
                }


                string em = (IsEmail(Email) + IsEmail(Email2) + IsEmail(Email3)).Trim();

                string txt = (fio + addr + phones + em).Trim();
                return txt;
            }
            set
            {
                allData = value;
            }
        }

        public string IsData(string data)
        {
            if(data==null || data=="")
            {
                return "";
            }
            return data.Trim() + " ";
        }

        public string IsEmail(string email)
        {
            if(email==null || email=="")
            {
                return "";
            }
            return email.Trim() + "\r\n";
        }

        public string AllEmails {
            get
            {
                if(allEmails != null)
                {
                    return allEmails;
                }

                return String.Format("{0}{1}{2}", IsEmail(Email), IsEmail(Email2), IsEmail(Email3)).Trim();
                    
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

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=>x.Deprecated=="0000-00-00 00:00:00") select c).ToList();
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

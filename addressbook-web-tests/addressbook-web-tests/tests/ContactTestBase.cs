using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_TEST)
            {
                List<ContactData> cFromUI = app.Contacts.GetContactList();
                List<ContactData> cFromDB = ContactData.GetAll();
                
                cFromDB.Sort();
                cFromUI.Sort();

                Assert.AreEqual(cFromUI, cFromDB);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        internal void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();

        }

        private void OpenRegistrationForm()
        {
            throw new NotImplementedException();
        }

        private void SubmitRegistration()
        {
            throw new NotImplementedException();
        }

        private void FillRegistrationForm(AccountData account)
        {
            throw new NotImplementedException();
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantis/login_page.php";
        }
    }
}

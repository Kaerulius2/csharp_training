using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.LogOut();
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWitInhValidCredentials()
        {
            app.Auth.LogOut();
            AccountData account = new AccountData("admin", "aecret");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

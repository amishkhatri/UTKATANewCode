using NUnit.Framework;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    [TestFixture("amish", "test123")]
    [TestFixture("amish", "test12345")]
    public class LoginUserTest
    {

        private string Testusername;
        private string Testpassword;

        public LoginUserTest(string testUserName, string testPassword)
        {
            Testusername = testUserName;
            Testpassword = testPassword;
        }


        [Test]
        public void ShouldLoginFailByInvalidUserCredentials(string username, string password)
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var IsUserValid = user.Login();

                /// --- Assert -----
                Assert.AreEqual("User login failed.", user.Message);

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }


        [Test]
        public void ShouldLoginSuccessfullywithValidLogin()
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var result = user.Add();

                if (result)
                {
                    var IsUserValid = user.Login();

                    if (IsUserValid)
                    {   /// --- Assert -----
                        Assert.AreEqual("The user logged in successfully.", user.Message);
                    }
                      

                }
                    

            }            
            catch(System.Exception ex)
            {
                throw ex;
            }

        }


       
       
    }
}
using NUnit.Framework;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    
    public class LoginUserTest
    {

        [Test]
        public void ShouldLoginFailByInvalidUserCredentials()
        {

                // --- Arrange -----
                var user = new User();
                user.UserName = "amish";
                user.Password = "test123";

                /// --- Act -----
                var IsUserValid = user.Login();

                /// --- Assert -----
                Assert.AreEqual("User login failed.", user.Message);


        }


        [Test]
        public void ShouldLoginSuccessfullywithValidLogin()
        {
                // --- Arrange -----
                var user = new User();
                user.UserName = "amish";
                user.Password = "test12345";

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


       
       
    }
}
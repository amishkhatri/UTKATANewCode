using NUnit.Framework;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    public class CreateUserTest
    {

        [Test]
        public void ShouldReturnPassWhenUserAddedSuccessfully()
        {
                // --- Arrange -----
                var user = new User();
                user.UserName = "amish";
                user.Password = "test123";

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("The user: " + user.UserName + " successfully added.", user.Message);
         
        }

        [Test]
        public void ShouldReturnFailWhenUserValidationFail()
        {
         
            // --- Arrange -----
                var user = new User();
                user.UserName = "amish";
                user.Password = "test";

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("Please enter password with minimum 6 alphanumeric characters.", user.Message);
            
        }

        [Test]
        public void ShouldReturnFailWhenUserFieldsEmpty()
        {
                // --- Arrange -----
                var user = new User();
                user.UserName = "";
                user.Password = "";

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("All fields are mandatory.", user.Message);
            

        }

        [Test]
        public void ShouldFailtoAddUserWhenPasswordIsWeak()
        {
                // --- Arrange -----
                var user = new User();
                user.UserName = "amish";
                user.Password = "testtt";

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("Please enter password with minimum 6 alphanumeric characters.", user.Message);
            
        }



    }
}
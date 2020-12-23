using NUnit.Framework;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    [TestFixture("amish", "test123")]
    [TestFixture("amish123", "test123")]
    [TestFixture("", "")]
    [TestFixture("amish", "testtt")]
    public class CreateUserTest
    {

        private string Testusername;
        private string Testpassword;

        public CreateUserTest(string testUserName, string testPassword)
        {
            Testusername = testUserName;
            Testpassword = testPassword;
        }
                
        [Test]
        public void ShouldReturnPassWhenUserAddedSuccessfully()
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("The user: " + user.UserName + " successfully added.", user.Message);
            }            
            catch(System.Exception ex)
            {
                throw ex;
            }

        }

        [Test]
        public void ShouldReturnFailWhenUserValidationFail()
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("Please enter password with minimum 6 alphanumeric characters.", user.Message);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        [Test]
        public void ShouldReturnFailWhenUserFieldsEmpty()
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("All fields are mandatory.", user.Message);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        [Test]
        public void ShouldFailtoAddUserWhenPasswordIsWeak()
        {
            try
            {
                // --- Arrange -----
                var user = new User();
                user.UserName = this.Testusername;
                user.Password = this.Testpassword;

                /// --- Act -----
                var result = user.Add();

                /// --- Assert -----
                Assert.AreEqual("Please enter password with minimum 6 alphanumeric characters.", user.Message);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }



    }
}
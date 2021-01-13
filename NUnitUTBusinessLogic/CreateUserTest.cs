using NUnit.Framework;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    public class CreateUserTest
    {

        User _user;

        [SetUp]
        public void Init()
        {
            _user = new User();
            _user.UserName = "mmanish";
            
            var result = _user.Create();
        }


        // TO DO - Should return pass when user added successfully but without password
        // 1- rewrite one test for username validate (valid user)
        // 2- message validation (two params are required however password in any format) - DONE

        // TODO - 

        [Test]
        public void ShouldReturn_Success_When_Supplied_User_Validated_Successfully()
        {

            // --- Arrange -----
            User user = new User();
            user.UserName = "amish";
            
            Validator validator = new Validator();

            var result = validator.IsUserNameValid(user.UserName);
            /// --- Act -----            

            /// --- Assert -----
            Assert.IsTrue(result);

        }


        [Test]
        public void ShouldReturn_Success_When_UserName_Password_Added_Successfully()
        {

            // --- Arrange -----            
            User user = new User();
            user.UserName = "amish";
            user.Password = "amish123";

            /// --- Act -----            
            var result = user.Add();

            /// --- Assert -----
            Assert.AreEqual("User creation successful", user.Message);

        }

        // TODO 1- rewrite one test for username validate (valid user) 
        //missing validation of post user create - 
        [Test]
        public void Should_Return_Fail_Validation_When_UserName_Is_Valid_And_Password_Is_NotSupplied_Per_Criteria()
        {

            // --- Arrange -----
            var user = new User();
            user.UserName = "amish";
            user.Password = "test";

            /// --- Act -----
            Validator validator = new Validator();
            var result= validator.IsPasswordValid(user.Password);

            /// --- Assert -----
            Assert.IsFalse(result);


        }



        [Test]
        public void Should_Return_Fail_When_UserName_Is_Valid_And_Password_Is_NotSupplied_Per_Not_Numeric_Criteria()
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

        // to do 

        [Test]
        public void Should_Return_Fail_In_Validation_When_Supplied_User_Fields_Are_Empty()
        {
            // --- Arrange -----
            var user = new User();
            user.UserName = "";
            user.Password = "";

            /// --- Act -----
            Validator validator = new Validator();
            var result = validator.IsUserNameValid(user.UserName) & validator.IsUserNameValid(user.Password);


            /// --- Assert -----
            Assert.IsFalse(result);


        }


        [Test]
        public void Should_Return_Fail_When_Supplied_User_Fields_Are_Empty()
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

        // TODO -  one test per acceptance criteria (one test one responsibility) 
        // Done - create another test to check 6 digit

        [Test]
        public void Should_Fail_To_Add_User_When_Password_Is_Weak()
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

        [Test]
        public void Should_Fail_To_Add_New_User_When_Password_Is_Not_6_Digits()
        {
            // --- Arrange -----
            var user = new User();
            user.UserName = "amish";
            user.Password = "tes";

            /// --- Act -----
            var result = user.Add();

            /// --- Assert -----
            Assert.AreEqual("Please enter password with minimum 6 alphanumeric characters.", user.Message);

        }

        // New Test cases

        //Sprint 1 AC 3 
        [Test]
        public void ShouldReturn_Success_When_Supplied_User_Validated_Successful()
        {

            // --- Arrange -----
            User user = new User();
            user.UserName = "manish";

            Validator validator = new Validator();

            var result = validator.IsUserNameValid(user.UserName);
            /// --- Act -----            

            /// --- Assert -----
            Assert.IsTrue(result);

        }

        //Sprint 1 AC 4 
        [Test]
        public void ShouldReturn_Success_When_UserName_Is_Valid_And_Default_Password_test1234()
        {

            // --- Arrange -----            
            User user = new User();
            user.UserName = "manish";
            
            /// --- Act -----            
            var result = user.Create();

            /// --- Assert -----
            Assert.AreEqual("User creation successful", user.Message);

        }

        //Sprint 3 AC 4
        [Test]
        public void Should_Login_Successfully_With_When_Password_Change_From_Default()
        {
            // --- Arrange -----
            _user.UserName = "mmanish";
            
            /// --- Act -----
            var result = _user.Update("test789");

            /// --- Assert -----
            Assert.AreEqual("Password change successful", _user.Message);

        }




    }
}
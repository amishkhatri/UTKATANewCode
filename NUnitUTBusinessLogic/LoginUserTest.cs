using NUnit.Framework;
using System;
using ut.businesslogic.user;

namespace ut.businesslogic.tests.createuser
{
    
    public class LoginUserTest
    {

        private User _user;

        [SetUp]
        public void Init()
        {
            _user = new User();
            _user.UserName = "manish";
            //_user.Password = "test1234";
            var result = _user.Create();
        }

        [Test]
        public void Should_Login_Fail_When_Invalid_User_And_Password_Supplied()
        {

            _user.UserName = "manis";

            /// --- Act -----
            var IsUserValid = _user.Login();

            /// --- Assert -----
            Assert.AreEqual("User login failed.", _user.Message);

        }


        [Test]
        public void Should_GetUser_Successfully_When_Valid_User_Added_Successfully()
        {
            // --- Arrange -----

            var user = new User();
            user.UserName = "amish";
            user.Password = "test12345";

            /// --- Act -----
            if (user.GetUser.ContainsKey(user.UserName))
            {
                /// --- Assert -----
                Assert.IsTrue(string.Equals(user.GetUser[user.UserName].ToString(), user.Password));

            }
        }


        [Test]
        public void Should_Login_Successfully_When_Valid_UserName_And_Password_Supplied()
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


        // New Test cases
        // Sprint 2 :  AC 2

        [Test]
        public void Should_Login_Successfully_When_Valid_UserName_And_Default_Password_test1234_Supplied()
        {
            // --- Arrange -----
            _user.UserName = "manish";
            _user.Password = "test1234";

            /// --- Act -----
            var IsUserValid = _user.Login();

            /// --- Assert -----
            Assert.IsTrue(IsUserValid);

        }

        [Test]
        public void Should_Login_Successfully_With_Messge_When_Valid_UserName_And_Default_Password_test1234_Supplied()
        {
            // --- Arrange -----
            _user.UserName = "manish";
            _user.Password = "test1234";

            /// --- Act -----
            var IsUserValid = _user.Login();

            /// --- Assert -----
            Assert.AreEqual("The user logged in successfully.", _user.Message);

        }



    }
}
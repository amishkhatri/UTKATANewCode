using System;
using System.Collections.Generic;
using System.Text;

namespace ut.businesslogic.user
{

    public class User
    {
        public static Dictionary<string, string> Users = new Dictionary<string, string>();
        private static Validator validator = new Validator();

        #region Properties  

        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region Methods

        //Add a new user with user name only characters
        public bool Add()
        {
            bool result = false;

            try
            {
                if (!(validator.IsValidFields(this.UserName, this.Password)))
                    this.Message = "All fields are mandatory.";
                else
                    if (validator.IsUserNameValid(this.UserName))
                    {
                        Users.Add(this.UserName,this.Password);
                        this.Message = "The user: " + this.UserName + " successfully added.";
                        result = true;
                    }
                    else
                        this.Message = "Only characters are allowed in the user name field.";
             
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion

    }
}

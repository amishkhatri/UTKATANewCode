using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ut.businesslogic.user
{
    // User Class
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
        public bool Login()
        {
            bool result = false;

            try
            {
                //result = String.Compare( Users[this.UserName],(this.Password.Trim()),false) ? true : false;
                result = Users.Where(x => x.Key == this.UserName.Trim()).Select(x => this.Password.Trim()).Count() >0 ? true : false;

                this.Message = result == true ? "The user logged in successfully." : "User login failed."; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }

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
                        if (validator.IsPasswordValid(this.Password))
                        {
                            Users.Add(this.UserName, this.Password);
                            this.Message = "The user: " + this.UserName + " successfully added.";
                            result = true;
                        }
                        else
                            this.Message = "Please enter password with minimum 6 alphanumeric characters.";
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

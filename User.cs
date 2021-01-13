using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ut.businesslogic.user
{
    // User Class
    public class User
    {
        // public static Dictionary<string, string> Users = new Dictionary<string, string>();
        private Dictionary<string, string> _user = new Dictionary<string, string>();
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

        
        public Dictionary<string, string> GetUser
        {
            get { return _user; }
            set { _user = value; }
        }


        #region Methods
        //Login user by validating from Users Dictionary 
        public bool Login()
        {
            bool result = false;

            try
            { 

                result = GetUser.Where(x => x.Key == this.UserName.Trim()).Select(x => this.Password.Trim()).Count() >0 ? true : false;

                this.Message = result == true ? "The user logged in successfully." : "User login failed."; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;

        }


        public bool Update(string newpassword)
        {
            bool result = false;
            
            try
            {
                result = GetUser.Where(x => x.Key == this.UserName.Trim()).Select(x => this.Password.Trim()).Count() > 0 ? true : false;
                                                
                if (result)
                {
                    GetUser[this.UserName] = newpassword;
                    this.Message = "Password change successful";
                }
                    
                
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }

        //Add a new user with user name only characters with password strength
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
                            GetUser.Add(this.UserName, this.Password);
                        this.Message = "User creation successful";
                        //this.Message = "The user: " + this.UserName + " with password : " + this.Password + " successfully added.";
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


        public bool Create()
        {
            bool result = false;

            this.Password = string.IsNullOrEmpty(this.Password)? "test1234" : this.Password;

            try
            {
                if (!(validator.IsValidFields(this.UserName, this.Password)))
                    this.Message = "All fields are mandatory.";
                else
                    if (validator.IsUserNameValid(this.UserName))
                {
                    if (validator.IsPasswordValid(this.Password))
                    {
                        GetUser.Add(this.UserName, this.Password);
                        this.Message = "User creation successful";                        
                        result = true;
                    }
                    else
                        this.Message = "Please enter password with minimum 6 alphanumeric characters.";
                }
                else
                    this.Message = "Only characters are allowed in the user name field.";

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        #endregion

    }
}

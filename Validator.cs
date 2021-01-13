using System;


namespace ut.businesslogic.user
{
    public class Validator
    {
        public static string userPattern = @"^[a-zA-Z]+$";
        public static string passwordPattern1 = @"\b[a-zA-Z0-9]{6,50}\b";
        public static string passwordPattern2 = @"^(\w*(\d+[a-zA-Z]|[a-zA-Z]+\d)\w*)+$";

        public bool IsValidFields(string username,string password)
        {
            
            bool result = false;

            try
            {
                // result = ((!string.IsNullOrEmpty(username)) && (!string.IsNullOrEmpty(password))) ? true : false;
                result = (!string.IsNullOrEmpty(username));

            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            return result;
        }

        public bool IsPasswordValid(string inputpassword)
        {
            bool regExPass = false;
            bool result = false;

            //if (string.IsNullOrEmpty(inputpassword)) return true;

            try
            {
                regExPass = System.Text.RegularExpressions.Regex.IsMatch(inputpassword, passwordPattern1);

                if (regExPass)
                    result = System.Text.RegularExpressions.Regex.IsMatch(inputpassword, passwordPattern2);

            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;

        }

        public bool IsUserNameValid(string username)
        {
            bool result = false;
         
            try
            {
                result = System.Text.RegularExpressions.Regex.IsMatch(username, userPattern) ? true : false;
            }
            catch (System.Exception ex)
            {
                result = false;
                throw ex;
            }
            return result;

        }


      
    }
}

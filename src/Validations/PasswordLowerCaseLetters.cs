using System.Text.RegularExpressions;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordLowerCaseLetters : IPasswordLowerCaseLetters
    {
        protected string _password;

        public int GetQuantityOfLowerCaseLetters()
        { 
            return _password.Length - Regex.Replace(_password, "[a-z]", "").Length;
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;

            return GetQuantityOfLowerCaseLetters() >= PasswordSettings.NUMBER_OF_LOWER_CASE;
        }
    }
}

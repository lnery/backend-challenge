using System.Text.RegularExpressions;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordUpperCaseLetters : IPasswordUpperCaseLetters
    {
        protected string _password;

        public int GetQuantityOfUpperCaseLetters()
        {
            return _password.Length - Regex.Replace(_password, "[A-Z]", "").Length;
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;

            return GetQuantityOfUpperCaseLetters() >= PasswordSettings.NUMBER_OF_UPPER_CASE;
        }
    }
}

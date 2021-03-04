using System.Text.RegularExpressions;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordSpecialCharacters : IPasswordSpecialCharacters
    {
        protected string _password;
        public int GetQuantityOfSpecialCharacters()
        {
            return Regex.Replace(_password, "[a-zA-Z0-9]", "").Length;
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;

            return GetQuantityOfSpecialCharacters() >= PasswordSettings.NUMBER_OF_SPECIAL_CHARS;
        }
    }
}

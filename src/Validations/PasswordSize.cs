using System;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordSize : IPasswordSize
    {
        protected string _password;

        public int GetQuantityOfCharacters()
        {
            return Math.Min(PasswordSettings.NUMBER_OF_CHARACTERS, _password.Length);
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;
        
            return GetQuantityOfCharacters() >= PasswordSettings.NUMBER_OF_CHARACTERS;
        }
    }
}

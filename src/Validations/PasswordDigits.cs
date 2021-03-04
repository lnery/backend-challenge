using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordDigits : IPasswordDigits
    {
        protected string _password;

        public int GetQuantityOfDigits()
        {
            return _password.Length - Regex.Replace(_password, "[0-9]", "").Length;
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;

            return GetQuantityOfDigits() >= PasswordSettings.NUMBER_OF_DIGITS;
        }
    }
}

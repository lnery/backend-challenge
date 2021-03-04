using System;
using System.Text.RegularExpressions;
using Validations.Constants;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordValidation : IValidation
    {
        public readonly string _password;

        public int QuantityOfCharacters
        { 
            get { 
                return Math.Min(PasswordSettings.NUMBER_OF_CHARACTERS, _password.Length); 
            } 
        }
        public int QuantityOfDigits
        {
            get
            {
                return _password.Length - Regex.Replace(_password, "[0-9]", "").Length;
            }
        }
        public int QuantityOfLowerCaseLetters
        {
            get
            {
                return _password.Length - Regex.Replace(_password, "[a-z]", "").Length;
            }
        }
        public int QuantityOfUpperCaseLetters
        {
            get
            {
                return _password.Length - Regex.Replace(_password, "[A-Z]", "").Length;
            }
        }
        public int QuantityOfSpecialCharacters
        {
            get
            {
                return Regex.Replace(_password, "[a-zA-Z0-9]", "").Length;
            }
        }
        public bool ContainsRepeatedCharacters
        {
            get
            {
                var regex = new Regex(@"(\w)*.*\1");

                return regex.IsMatch(_password);
            }
        }

        public PasswordValidation(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("A senha não foi informada");

            this._password = password;
        }

        public bool IsValid()
        {
            return ValidateSize() && ValidateNumberOfDigits() && ValidateNumberOfLowerCaseLetters() && ValidaNumberOfUpperCaseLetters() && !ContainsRepeatedCharacters;
        }

        private bool ValidateSize()
        {
            return QuantityOfCharacters >= PasswordSettings.NUMBER_OF_CHARACTERS;
        }

        private bool ValidateNumberOfDigits()
        {
            return QuantityOfDigits >= PasswordSettings.NUMBER_OF_DIGITS;
        }

        private bool ValidateNumberOfLowerCaseLetters()
        {
            return QuantityOfLowerCaseLetters >= PasswordSettings.NUMBER_OF_LOWER_CASE;
        }

        private bool ValidaNumberOfUpperCaseLetters()
        {
            return QuantityOfUpperCaseLetters >= PasswordSettings.NUMBER_OF_UPPER_CASE;
        }
    }
}

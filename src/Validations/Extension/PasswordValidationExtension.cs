using System;
using System.Collections.Generic;
using System.Text;
using Validations.Contants;
using Validations.Enums;

namespace Validations.Extension
{
    public static class PasswordValidationExtension
    {
        public static PasswordStrength GetPasswordStrength(this PasswordValidation passwordValidation)
        {
            int score = GetPasswordScore(passwordValidation);

            if (score < 50)
                return PasswordStrength.Unacceptable;
            else if (score < 60)
                return PasswordStrength.Weak;
            else if (score < 80)
                return PasswordStrength.Acceptable;
            else if (score < 100)
                return PasswordStrength.Strong;
            else
                return PasswordStrength.Secure;
        }

        private static int GetPasswordScore(PasswordValidation passwordValidation)
        {
            if (string.IsNullOrEmpty(passwordValidation._password)) return 0;

            int scoreBySize = GetScoreBySize(passwordValidation.QuantityOfCharacters);
            int scoreByLowerCase = GetScoreByLowerCase(passwordValidation.QuantityOfLowerCaseLetters);
            int scoreScoreByUpperCase = GetScoreByUpperCase(passwordValidation.QuantityOfUpperCaseLetters);
            int scoreByDigits = GetScoreByDigits(passwordValidation.QuantityOfDigits);
            int scoreBySpecialCharacters = GetScoreBySpecialCharacters(passwordValidation.QuantityOfSpecialCharacters);
            int scoreByRepeatedSequence = GetScoreByRepeatedSequence(passwordValidation.ContainsRepeatedCharacters);

            return scoreBySize + scoreByLowerCase + scoreScoreByUpperCase + scoreByDigits + scoreBySpecialCharacters - scoreByRepeatedSequence;
        }

        private static int GetScoreBySize(int size)
        {
            return size * PasswordScore.BY_SIZE;
        }

        private static int GetScoreByLowerCase(int quantityOfLowerCase)
        {
            return Math.Min(2, quantityOfLowerCase) * PasswordScore.BY_LOWER_CASE;
        }

        private static int GetScoreByUpperCase(int quantityOfUpperCase)
        {
            return Math.Min(2, quantityOfUpperCase) * PasswordScore.BY_UPPER_CASE;
        }

        private static int GetScoreByDigits(int quantityOfDigits)
        {
            return Math.Min(2, quantityOfDigits) * PasswordScore.BY_DIGITS;
        }

        private static int GetScoreBySpecialCharacters(int quantityOfSpecialChars)
        {
            return Math.Min(2, quantityOfSpecialChars) * PasswordScore.BY_SPECIAL_CHARS;
        }

        private static int GetScoreByRepeatedSequence(bool hasRepeatedSequence)
        {
            if (hasRepeatedSequence)
            {
                return PasswordScore.BY_REPEATED_SEQUENCE;
            }
            else
            {
                return 0;
            }
        }
    }
}

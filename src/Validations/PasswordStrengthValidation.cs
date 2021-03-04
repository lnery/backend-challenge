using System;
using Validations.Contants;
using Validations.Enums;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordStrengthValidation : IPasswordStrengthValidation
    {
        protected PasswordValidation passwordValidation;

        public PasswordStrengthValidation(IPasswordValidation passwordValidation)
        {
            this.passwordValidation = (PasswordValidation)passwordValidation;
        }

        public int GetPasswordScore()
        {
            if (string.IsNullOrEmpty(passwordValidation.password)) return 0;

            int scoreBySize = GetScoreBySize(passwordValidation.passwordSize.GetQuantityOfCharacters());
            int scoreByLowerCase = GetScoreByLowerCase(passwordValidation.passwordLowerCaseLetters.GetQuantityOfLowerCaseLetters());
            int scoreScoreByUpperCase = GetScoreByUpperCase(passwordValidation.passwordUpperCaseLetters.GetQuantityOfUpperCaseLetters());
            int scoreByDigits = GetScoreByDigits(passwordValidation.passwordDigits.GetQuantityOfDigits());
            int scoreBySpecialCharacters = GetScoreBySpecialCharacters(passwordValidation.passwordSpecialCharacters.GetQuantityOfSpecialCharacters());
            int scoreByRepeatedSequence = GetScoreByRepeatedSequence(passwordValidation.passwordRepeatedCharacters.ContainsRepeatedCharacters());

            return scoreBySize + scoreByLowerCase + scoreScoreByUpperCase + scoreByDigits + scoreBySpecialCharacters - scoreByRepeatedSequence;
        }

        public PasswordStrength GetPasswordStrength()
        {
            int score = GetPasswordScore();

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

        public int GetScoreBySize(int size)
        {
            return size * PasswordScore.BY_SIZE;
        }

        public int GetScoreByLowerCase(int quantityOfLowerCase)
        {
            return Math.Min(2, quantityOfLowerCase) * PasswordScore.BY_LOWER_CASE;
        }

        public int GetScoreByUpperCase(int quantityOfUpperCase)
        {
            return Math.Min(2, quantityOfUpperCase) * PasswordScore.BY_UPPER_CASE;
        }

        public int GetScoreByDigits(int quantityOfDigits)
        {
            return Math.Min(2, quantityOfDigits) * PasswordScore.BY_DIGITS;
        }

        public int GetScoreBySpecialCharacters(int quantityOfSpecialChars)
        {
            return Math.Min(2, quantityOfSpecialChars) * PasswordScore.BY_SPECIAL_CHARS;
        }

        public int GetScoreByRepeatedSequence(bool hasRepeatedSequence)
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

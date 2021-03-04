using Validations.Interfaces;

namespace Validations
{
    public class PasswordValidation : IPasswordValidation
    {
        public string password { get; private set; }

        public readonly IPasswordSize passwordSize;
        public readonly IPasswordDigits passwordDigits;
        public readonly IPasswordLowerCaseLetters passwordLowerCaseLetters;
        public readonly IPasswordUpperCaseLetters passwordUpperCaseLetters;
        public readonly IPasswordSpecialCharacters passwordSpecialCharacters;
        public readonly IPasswordRepeatedCharacters passwordRepeatedCharacters;

        public PasswordValidation(IPasswordSize passwordSize, IPasswordDigits passwordDigits, IPasswordLowerCaseLetters passwordLowerCaseLetters, IPasswordUpperCaseLetters passwordUpperCaseLetters, IPasswordSpecialCharacters passwordSpecialCharacters, IPasswordRepeatedCharacters passwordRepeatedCharacters)
        {
            this.passwordSize = passwordSize;
            this.passwordDigits = passwordDigits;
            this.passwordLowerCaseLetters = passwordLowerCaseLetters;
            this.passwordUpperCaseLetters = passwordUpperCaseLetters;
            this.passwordSpecialCharacters = passwordSpecialCharacters;
            this.passwordRepeatedCharacters = passwordRepeatedCharacters;
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            this.password = password;

            return passwordSize.IsValid(password) && passwordDigits.IsValid(password) && passwordLowerCaseLetters.IsValid(password) && passwordUpperCaseLetters.IsValid(password) && passwordSpecialCharacters.IsValid(password) && passwordRepeatedCharacters.IsValid(password);
        }
    }
}

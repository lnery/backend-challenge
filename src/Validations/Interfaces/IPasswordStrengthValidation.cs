using System;
using System.Collections.Generic;
using System.Text;
using Validations.Enums;

namespace Validations.Interfaces
{
    public interface IPasswordStrengthValidation
    {
        PasswordStrength GetPasswordStrength();
        int GetPasswordScore();
        int GetScoreBySize(int size);
        int GetScoreByLowerCase(int quantityOfLowerCase);
        int GetScoreByUpperCase(int quantityOfUpperCase);
        int GetScoreByDigits(int quantityOfDigits);
        int GetScoreBySpecialCharacters(int quantityOfSpecialChars);
        int GetScoreByRepeatedSequence(bool hasRepeatedSequence);
    }
}

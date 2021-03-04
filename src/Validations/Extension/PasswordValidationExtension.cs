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
            var passwordStrengthValidation = new PasswordStrengthValidation(passwordValidation);

            return passwordStrengthValidation.GetPasswordStrength();
        }
    }
}

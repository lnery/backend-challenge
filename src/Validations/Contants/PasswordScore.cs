using System;
using System.Collections.Generic;
using System.Text;

namespace Validations.Contants
{
    public static class PasswordScore
    {
        public const int BY_SIZE = 7;
        public const int BY_LOWER_CASE = 5;
        public const int BY_UPPER_CASE = 5;
        public const int BY_DIGITS = 6;
        public const int BY_SPECIAL_CHARS = 5;
        public const int BY_REPEATED_SEQUENCE = 30;
    }
}

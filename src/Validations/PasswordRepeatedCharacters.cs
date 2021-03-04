using System.Text.RegularExpressions;
using Validations.Interfaces;

namespace Validations
{
    public class PasswordRepeatedCharacters : IPasswordRepeatedCharacters
    {
        protected string _password;
        public bool ContainsRepeatedCharacters()
        {
            var regex = new Regex(@"(\w)*.*\1");

            return !regex.IsMatch(_password);
        }

        public bool IsValid(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            _password = password;

            return ContainsRepeatedCharacters();
        }
    }
}

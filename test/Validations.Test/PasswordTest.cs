using System;
using System.Text.RegularExpressions;
using Xunit;
using Validations.Extension;
using Validations.Constants;
using Validations.Enums;

namespace Validations.Test
{
    public class PasswordTest
    {
        [Theory]
        //[InlineData("")]
        //[InlineData("aa")]
        //[InlineData("ab")]
        //[InlineData("AAAbbbCc")]
        //[InlineData("AbTp9!foo")]
        [InlineData("AbTp9!fok")]
        public void SenhaDeveSerValida(string senha)
        {
            var isValid = new PasswordValidation(senha).IsValid();

            Assert.True(isValid, "A senha informada e invalida.");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aaa")]
        //[InlineData("aaaaaaaa")]
        [InlineData("aaaaaaaaa")]
        public void SenhaDevePossuir9CaracteresOuMais(string senha)
        {
            var password = new PasswordValidation(senha);
            
            Assert.True(password.QuantityOfCharacters >= 9, "A senha deve possuir 9 ou mais caracteres.");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aaa")]
        [InlineData("aaa1aaaaa")]
        public void SenhaDevePossuirAoMenos1Digito(string senha)
        {
            var password = new PasswordValidation(senha);

            Assert.True(password.QuantityOfDigits >= PasswordSettings.NUMBER_OF_DIGITS, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_DIGITS} dígito(s).");
        }

        [Theory]
        //[InlineData("AA")]
        [InlineData("AAa")]
        public void SenhaDevePossuirAoMenos1LetraMinuscula(string senha)
        {
            var password = new PasswordValidation(senha);

            Assert.True(password.QuantityOfLowerCaseLetters >= PasswordSettings.NUMBER_OF_LOWER_CASE, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_LOWER_CASE} letra(s) minúscula(s).");
        }

        [Theory]
        //[InlineData("aa")]
        [InlineData("aaA")]
        public void SenhaDevePossuirAoMenos1LetraMaiuscula(string senha)
        {
            var password = new PasswordValidation(senha);

            Assert.True(password.QuantityOfUpperCaseLetters >= PasswordSettings.NUMBER_OF_UPPER_CASE, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_UPPER_CASE} letra(s) maiúscula(s).");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aa@")]
        //[InlineData("aa#")]
        [InlineData("aa!@#$%^&*()_+{}?~`")]
        public void SenhaDevePossuirAoMenos1CaracterEspecial(string senha)
        {
            var password = new PasswordValidation(senha);

            Assert.True(password.QuantityOfSpecialCharacters >= PasswordSettings.NUMBER_OF_SPECIAL_CHARS, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_SPECIAL_CHARS} caractere(s) especial(ais).");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("abbc")]
        [InlineData("aabc")]
        //[InlineData("abcdefgh")]
        public void SenhaNaoDevePossuirCaracteresRepetidos(string senha)
        {
            var password = new PasswordValidation(senha);

            Assert.True(password.ContainsRepeatedCharacters, $"A senha não possuir caracteres repetidos");
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public void SenhaDeveSerNoMinimoAceitavel(string senha)
        {
            var password = new PasswordValidation(senha);

            var isValid = new PasswordValidation(senha).IsValid();

            Assert.True(isValid, "A senha informada e invalida.");

            var forcaSenha = password.GetPasswordStrength();

            Assert.False((forcaSenha == PasswordStrength.Unacceptable || forcaSenha == PasswordStrength.Weak), $"A senha não é forte o suficiente.");
        }
    }
}

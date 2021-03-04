using System;
using System.Text.RegularExpressions;
using Xunit;
using Validations.Extension;
using Validations.Constants;
using Validations.Enums;
using Validations.Interfaces;

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
            var isValid = new PasswordValidation(new PasswordSize(), new PasswordDigits(), new PasswordLowerCaseLetters(), new PasswordUpperCaseLetters(), new PasswordSpecialCharacters(), new PasswordRepeatedCharacters()).IsValid(senha);

            Assert.True(isValid, "A senha informada e invalida.");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aaa")]
        //[InlineData("aaaaaaaa")]
        [InlineData("aaaaaaaaa")]
        public void SenhaDevePossuir9CaracteresOuMais(string senha)
        {
            var password = new PasswordSize();
            password.IsValid(senha);
            
            Assert.True(password.GetQuantityOfCharacters() >= 9, "A senha deve possuir 9 ou mais caracteres.");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aaa")]
        [InlineData("aaa1aaaaa")]
        public void SenhaDevePossuirAoMenos1Digito(string senha)
        {
            var password = new PasswordDigits();
            password.IsValid(senha);

            Assert.True(password.GetQuantityOfDigits() >= PasswordSettings.NUMBER_OF_DIGITS, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_DIGITS} dígito(s).");
        }

        [Theory]
        //[InlineData("AA")]
        [InlineData("AAa")]
        public void SenhaDevePossuirAoMenos1LetraMinuscula(string senha)
        {
            var password = new PasswordLowerCaseLetters();
            password.IsValid(senha);

            Assert.True(password.GetQuantityOfLowerCaseLetters() >= PasswordSettings.NUMBER_OF_LOWER_CASE, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_LOWER_CASE} letra(s) minúscula(s).");
        }

        [Theory]
        //[InlineData("aa")]
        [InlineData("aaA")]
        public void SenhaDevePossuirAoMenos1LetraMaiuscula(string senha)
        {
            var password = new PasswordUpperCaseLetters();
            password.IsValid(senha);

            Assert.True(password.GetQuantityOfUpperCaseLetters() >= PasswordSettings.NUMBER_OF_UPPER_CASE, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_UPPER_CASE} letra(s) maiúscula(s).");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("aa@")]
        //[InlineData("aa#")]
        [InlineData("aa!@#$%^&*()_+{}?~`")]
        public void SenhaDevePossuirAoMenos1CaracterEspecial(string senha)
        {
            var password = new PasswordSpecialCharacters();
            password.IsValid(senha);

            Assert.True(password.GetQuantityOfSpecialCharacters() >= PasswordSettings.NUMBER_OF_SPECIAL_CHARS, $"A senha deve possuir ao menos {PasswordSettings.NUMBER_OF_SPECIAL_CHARS} caractere(s) especial(ais).");
        }

        [Theory]
        //[InlineData("aa")]
        //[InlineData("abbc")]
        //[InlineData("aabc")]
        [InlineData("abcdefgh")]
        public void SenhaNaoDevePossuirCaracteresRepetidos(string senha)
        {
            var password = new PasswordRepeatedCharacters();
            password.IsValid(senha);

            Assert.False(password.ContainsRepeatedCharacters(), $"A senha não deve possuir caracteres repetidos em sequencia");
        }

        [Theory]
        [InlineData("AbTp9!fok")]
        public void SenhaDeveSerNoMinimoAceitavel(string senha)
        {
            var password = new PasswordValidation(new PasswordSize(), new PasswordDigits(), new PasswordLowerCaseLetters(), new PasswordUpperCaseLetters(), new PasswordSpecialCharacters(), new PasswordRepeatedCharacters());

            var isValid = password.IsValid(senha);

            Assert.True(isValid, "A senha informada e invalida.");

            var forcaSenha = password.GetPasswordStrength();

            Assert.False((forcaSenha == PasswordStrength.Unacceptable || forcaSenha == PasswordStrength.Weak), $"A senha não é forte o suficiente.");
        }
    }
}

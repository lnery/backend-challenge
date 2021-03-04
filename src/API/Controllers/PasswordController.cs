using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validations;
using Validations.Extension;
using Validations.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        protected readonly PasswordValidation _passwordValidation;

        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger, IPasswordValidation passwordValidation)
        {
            _logger = logger;
            _passwordValidation = (PasswordValidation)passwordValidation;
        }

        [HttpPost("Validate")]
        public async Task<bool> ValidatePassword(string password)
        {
            return await Task.FromResult<bool>(_passwordValidation.IsValid(password));
        }

        [HttpGet("PasswordStrength")]
        public async Task<string> GetPasswordStrength(string password)
        {
            if (!_passwordValidation.IsValid(password))
                return await Task.FromResult<string>("A senha é inválida");

            var passwordStrength = _passwordValidation.GetPasswordStrength();

            return passwordStrength switch
            {
                Validations.Enums.PasswordStrength.Weak => await Task.FromResult<string>("A senha é fraca."),
                Validations.Enums.PasswordStrength.Acceptable => await Task.FromResult<string>("A senha é aceitavel."),
                Validations.Enums.PasswordStrength.Strong => await Task.FromResult<string>("A senha é forte."),
                Validations.Enums.PasswordStrength.Secure => await Task.FromResult<string>("A senha é segura."),
                _ => await Task.FromResult<string>("A senha não é aceitavel."),
            };
        }
    }
}

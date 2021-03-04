using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Validations;
using Validations.Extension;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        protected readonly PasswordValidation _passwordValidation;

        private readonly ILogger<PasswordController> _logger;

        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Validate")]
        public async Task<bool> ValidatePassword(string password)
        {
            var passwordValidation = new PasswordValidation(password);

            return await Task.FromResult<bool>(passwordValidation.IsValid());
        }

        [HttpGet("PasswordStrength")]
        public async Task<string> GetPasswordStrength(string password)
        {
            var passwordValidation = new PasswordValidation(password);

            if (!passwordValidation.IsValid())
                return await Task.FromResult<string>("A senha é inválida");

            var passwordStrength = passwordValidation.GetPasswordStrength();

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

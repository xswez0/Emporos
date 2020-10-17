using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporos.API.Auth.Controllers.ModelView
{
    public class AuthenticationRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(o => o.Login)
                .NotEmpty().WithMessage("ItemNumber can't be empty.");
            RuleFor(o => o.Password)
                .NotEmpty().WithMessage("ItemNumber can't be empty.");
        }
    }
}

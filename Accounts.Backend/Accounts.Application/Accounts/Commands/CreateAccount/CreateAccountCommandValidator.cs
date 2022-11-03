using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(createAccountCommand =>
                createAccountCommand.FullName).NotEmpty().MaximumLength(250);
            RuleFor(createAccountCommand =>
                createAccountCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}

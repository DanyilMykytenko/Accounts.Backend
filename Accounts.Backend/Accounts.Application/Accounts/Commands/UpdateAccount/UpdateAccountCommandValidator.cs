using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Commands.UpdateAccount
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(updateAccountCommand => updateAccountCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateAccountCommand => updateAccountCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateAccountCommand => updateAccountCommand.FullName)
                .NotEmpty().MaximumLength(250);
        }
    }
}

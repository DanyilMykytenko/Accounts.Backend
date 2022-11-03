using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Commands.DeleteAccount
{
    public class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
    {
        public DeleteAccountCommandValidator()
        {
            RuleFor(deleteAccountCommand => deleteAccountCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteAccountCommand => deleteAccountCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}

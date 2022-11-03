using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountDetails
{
    public class GetAccountDetailsQueryValidator : AbstractValidator<GetAccountDetailsQuery>
    {
        public GetAccountDetailsQueryValidator()
        {
            RuleFor(Account => Account.Id).NotEqual(Guid.Empty);
            RuleFor(Account => Account.UserId).NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQueryValidator : AbstractValidator<GetAccountListQuery>
    {
        public GetAccountListQueryValidator()
        {
            RuleFor(accounts => accounts.UserId).NotEqual(Guid.Empty);
        }
    }
}

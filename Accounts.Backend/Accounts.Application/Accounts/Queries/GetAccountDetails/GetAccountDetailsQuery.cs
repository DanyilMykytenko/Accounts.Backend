using MediatR;
using System;

namespace Accounts.Application.Accounts.Queries.GetAccountDetails
{
    public class GetAccountDetailsQuery : IRequest<AccountDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}

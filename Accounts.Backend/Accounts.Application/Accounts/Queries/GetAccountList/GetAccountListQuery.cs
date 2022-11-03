using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountList
{
    public class GetAccountListQuery : IRequest<AccountListVm>
    {
        public Guid UserId { get; set; }
    }
}

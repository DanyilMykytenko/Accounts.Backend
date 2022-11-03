using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Accounts.Queries.GetAccountList
{
    public class AccountListVm
    {
        public IList<AccountLookupDto> Accounts { get; set; }
    }
}

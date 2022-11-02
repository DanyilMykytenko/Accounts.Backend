using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Accounts.Domain;

namespace Accounts.Application.Interfaces
{
    public interface IAccountsDbContext
    {
        DbSet<Account> Accounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

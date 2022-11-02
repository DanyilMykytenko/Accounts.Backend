using Microsoft.EntityFrameworkCore;
using Accounts.Application.Interfaces;
using Accounts.Domain;
using Accounts.Persistence.EntityTypeConfigurations;

namespace Accounts.Persistence
{
    public class AccountsDbContext : DbContext, IAccountsDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
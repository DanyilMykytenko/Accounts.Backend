using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounts.Domain;

namespace Accounts.Persistence.EntityTypeConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(acc => acc.Id);
            builder.HasIndex(acc => acc.Id).IsUnique();
            builder.Property(acc => acc.FullName).HasMaxLength(250);
        }
    }
}
using Accounts.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Accounts.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            services.AddDbContext<AccountsDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("SqlDatabase"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            });
            services.AddScoped<IAccountsDbContext>(provider =>
            provider.GetService<AccountsDbContext>());
            return services;
        }
    }
}

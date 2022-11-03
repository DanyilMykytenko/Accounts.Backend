namespace Accounts.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AccountsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

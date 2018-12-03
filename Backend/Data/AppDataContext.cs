using Microsoft.EntityFrameworkCore;

namespace SavingsDeposits.Data
{
    public class AppDataContext : DbContext
    {
            public AppDataContext (DbContextOptions<AppDataContext> options)
                : base(options)
            {
            }

            public DbSet<Entities.SavingsDeposit> SavingDeposit { get; set; }
            public DbSet<Entities.User> Users { get; set; }
    }
}
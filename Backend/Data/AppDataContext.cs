using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SavingsDeposits.Entities;
using SavingsDeposits.Helpers;

namespace SavingsDeposits.Data
{
    public class AppDataContext : IdentityDbContext<User>
    {
            public AppDataContext (DbContextOptions<AppDataContext> options)
                : base(options)
            {
            }

            public DbSet<Entities.SavingsDeposit> SavingDeposit { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var appUserRole in Enum.GetNames(typeof(AppUserRole)))
            {
                builder.Entity<IdentityRole>().HasData(new IdentityRole(appUserRole){NormalizedName = appUserRole.ToUpperInvariant()});                
            }            
        }
    }
}
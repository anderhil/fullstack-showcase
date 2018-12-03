using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace SavingsDeposits.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int TokenExpiry { get; set; }
    }
}
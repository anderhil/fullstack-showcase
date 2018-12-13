using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SavingsDeposits.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        
        public string Role { get; set; }
    }
}
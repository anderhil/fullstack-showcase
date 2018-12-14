using System;

namespace SavingsDeposits.Entities
{
    public class ReportData
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime ReportDate { get; set; } 
        public string JsonObject { get; set; }
    }
}
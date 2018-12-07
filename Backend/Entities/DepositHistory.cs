using System;

namespace SavingsDeposits.Entities
{
    public class DepositHistory
    {
        public int Id { get; set; }
        
        public int SavingsDepositId { get; set; }
        
        public DateTime CalculationDate { get; set; }
        
        public decimal TotalProfitAfterTax { get; set; }

        public decimal ProfitTax { get; set; }
        public decimal ProfitBeforeTax { get; set; }
        public decimal ProfitAfterTax { get; set; }
    } 
}